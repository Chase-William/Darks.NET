using Darks.Core.Models.Jobs;
using Darks.Desktop.Logic.Args.Jobs;
using Darks.Desktop.Logic.Exceptions;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Dispatch;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Dispatch;
internal class WorkerExecutionManager
{
    private readonly ILogger<WorkerExecutionManager> _logger;
    private readonly ConcurrentQueue<ExecutableJob> _jobQueue = new();
    private readonly JobManagerFactory _jobManagerFactory;

    private readonly ProcessManager _processManager;
    private readonly MainMenuManager _mainMenuManager;
    private readonly RespawnManager _respawnManager;
    private readonly InventoryManager _inventoryManager;
    private readonly IdleStateManager _idleStateManager;

    public event EventHandler<JobChangedEventArgs>? JobManagerChanged;

    public ImmutableQueue<ExecutableJob> Queue => ImmutableQueue.CreateRange(_jobQueue);

    private JobManager? _jobManager;
    private JobManager? JobManager
    {
        get => _jobManager;
        set
        {
            if (_jobManager == value) return;
            var prev = _jobManager;
            _jobManager = value;
            JobManagerChanged?.Invoke(this, new JobChangedEventArgs(prev, _jobManager));
        }
    }

    private CancellationTokenSource? runnerCancellationToken = null; // Used for cancelling idle state
    private CancellationTokenSource? idleCancellationToken = null;
    private Task? runner = null;

    public WorkerExecutionManager(
        ILogger<WorkerExecutionManager> logger,
        JobManagerFactory jobManagerFactory,
        IdleStateManager idleStateManager,
        ProcessManager processManager,
        MainMenuManager mainMenuManager,
        RespawnManager respawnManager,
        InventoryManager inventoryManager)
    {
        _logger = logger;
        _jobManagerFactory = jobManagerFactory;
        _idleStateManager = idleStateManager;
        _processManager = processManager;
        _mainMenuManager = mainMenuManager;
        _respawnManager = respawnManager;
        _inventoryManager = inventoryManager;

        _idleStateManager.ErrorOnTick += async delegate
        { // Handle getting the worker back into idle-state if a serious issue has arrised
            await Operate(async () => await _idleStateManager.EnterIdleStateAsync((idleCancellationToken = new CancellationTokenSource()).Token));
        };
    }

    public void Notify()
    {
        if (runner is null && idleCancellationToken is null)
        {
            ExecuteJobsOtherwiseIdleIfNeeded();
        }
    }

    public void Add(ExecutableJob job)
    {
        _jobQueue.Enqueue(job);
        ExecuteJobsOtherwiseIdleIfNeeded();
    }

    private void ExecuteJobsOtherwiseIdleIfNeeded()
    {       
        runner ??= Task.Run(async () =>
        {
            // Determine if the worker is entering or already in idle state
            //
            // 1. If entering, we either cancel or wait until its done then leave
            // 2. If already in, we just leave idle state
            //
            // For now, we will just wait and then leave idle as its a simpler impl

            if (idleCancellationToken is not null)
            { // Cancel the idle state
                _logger.LogInformation("Canceling an idle operation to begin job.");
                await idleCancellationToken.CancelAsync();

                if (_idleStateManager.InIdle)
                { // If in idle, request to leave idle
                    _logger.LogInformation("Leaving idle state to begin job.");
                    await Operate(async () => await _idleStateManager.LeaveIdleStateAsync());
                }
                idleCancellationToken = null; // Reset token to null once complete                                        
            }

            await ProcessJobs();
            runnerCancellationToken = null;
            await Operate(async () => await _idleStateManager.EnterIdleStateAsync((idleCancellationToken = new CancellationTokenSource()).Token));

            runner = null; // Remove its reference once completed, allowing the first incoming job to start another
        }); // Create the long running task for this job and others in the queue
    }

    private async Task ProcessJobs()
    {
        do
        {
            try
            {
                if (!_jobQueue.TryDequeue(out ExecutableJob? job))
                    break; // No jobs left

                if (job is null)
                    break; // Return form this flow if no jobs are next

                _logger.LogInformation(
                    "Setting up the current job of type: {JobName} with id: {Id}.", 
                    job.Blueprint.GetType().Name, 
                    job.Blueprint.Id);
                JobManager = _jobManagerFactory.CreateJobManager(job);

                // Process the current job            
                await ProcessJob();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured when setting up a job with exception: {ExMsg}", ex.Message);
            }
        } while (true);

        // Unassign job manager at the end of processing
        JobManager = null;
    }

    private async Task ProcessJob()
    {       
        ArgumentNullException.ThrowIfNull(JobManager);

        _logger.LogInformation(
            "Now processing job {JobType} with id {Id}.", 
            JobManager.Job.Blueprint.GetType().Name, 
            JobManager.Job.Blueprint.Id);

        await Operate(async () => await JobManager.Run((runnerCancellationToken = new CancellationTokenSource()).Token));
    }

    private async Task Operate(Func<Task> operation)
    {
        do
        {
            try // Catch exceptions and use fallback routines
            {
                // Run the job with a cancellation token to cancel it if needed
                await operation();

                return; // Break out when successfully finished execution
            }
            catch (GameRestartException ex)
            { // The game needs to be restarted for the worker
                if (JobManager is null)
                {
                    _logger.LogError("An error occured when entering idle state with exception: {ExMsg}", ex.Message);
                }
                else
                {
                    _logger.LogWarning(
                        "An error occured when running job of type: {JobType} with id: {JobId} where the game needs to be restarted and the exception message states: {ExMsg}",
                        JobManager.Job.Blueprint.GetType().Name,
                        JobManager.Job.Blueprint.Id,
                        ex.Message);
                }

                //
                // Restart the process and re-join the same game session
                //

                int attempts = 0;
                do
                {
                    attempts++;
                    await _processManager.ExitAsync();
                    _logger.LogInformation("Closed Ark.");
                    await Task.Delay(30000); // Wait 30 seconds as Ark can linger
                    await _processManager.LaunchAsync();
                    _logger.LogInformation("Launched Ark.");

                    await Task.Delay(60000); // Wait a minute for ark to start regardless, then start checking afterwards

                    // Poll until homescreen seen or timeout
                    if (!await EnsureHomescreenReachedSuccessfully())
                        continue; // Try again

                    await Task.Delay(5000); // Wait for 5 seconds incase it just became visible

                    _logger.LogInformation("Attempting to click join last sessio button.");
                    // Attempt to join the last session
                    if (!await _mainMenuManager.JoinLastServer())
                    { // The game home screen was not visible
                        _logger.LogError("Was unable to join last session when recovering, closing ark and tryinging again...");
                        continue; // Try again
                    }

                    // TODO: If join last session fails a threshold amount, try joining the server another way

                    // Poll until something is recognized indicating that we have actually joined the server
                    // Otherwise try again and maybe try another way where we join the server # specifically

                    await Task.Delay(120000); // Wait for game to load, otherwise we can open inventory with no implant so he cant kill himself

                    if (!await EnsureJoinedServerSuccessfully())
                        continue; // Try again

                    // Now that the inventory is open, we can hand control over to the job
                    break;
                } while (attempts < 30); // Try a max of 30 times to get back in
                _logger.LogInformation("Successfully recovered using the recovery procedure.");
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogInformation("Canceling the current operation with exception: {ExMsg}.", ex.Message);
                return;
            }
            catch (Exception ex)
            { // A generic error has occured, therefore we probably can't fix this by iterating again so return out of this job's execution block
                if (JobManager is null)
                {
                    _logger.LogError("An error occured when entering idle with exception: {ExMsg}", ex.Message);
                }
                else
                {
                    _logger.LogError("An error occured when running job of type: {JobType} with id: {JobId} with exception: {ExMsg}",
                        JobManager.Job.Blueprint.GetType().Name,
                        JobManager.Job.Blueprint.Id,
                        ex.Message);
                }
                return; // Return as this issue is likely not something that can be fixed by trying again
            }
        } while (true);
    }

    private async Task<bool> EnsureHomescreenReachedSuccessfully()
    {
        const int Second = 1000;
        const int TwoMinutes = 2 * 60 * Second;
        for (int i = 0; i < TwoMinutes; i += Second)
        {
            await Task.Delay(Second);
            if (await _mainMenuManager.IsHomeScreenShowing())
            {
                _logger.LogInformation("Homescreen was found during recovery.");
                return true;
            }
        }
        _logger.LogWarning("Was unable to reach the homescreen on restart.");
        return false;
    }

    private async Task<bool> EnsureJoinedServerSuccessfully()
    {
        const int Second = 1000;
        const int TwoMinutes = 2 * 60 * Second;
        try
        {
            _logger.LogInformation("Waiting for visible death screen or inventory to be openable so we know we have successfully re-joined.");
            for (int i = 0; i < TwoMinutes; i += Second)
            {
                await Task.Delay(Second);
                if (await _respawnManager.IsRespawnScreenShowing())
                { // Death screen was found visible
                    _logger.LogInformation("Respawn screen was showing.");
                    return true;
                }
                if (await _inventoryManager.OpenAsync(Core.Enums.Inventory.Self))
                { // Inventory was openable
                    _logger.LogInformation("Inventory was openable.");
                    return true;
                }
            }
        }
        catch (Exception innerEx)
        {
            _logger.LogError(
                "An issue occured when trying to open the character inventory during recovery with exception: {ExMsg}. " +
                "Going to close ark and try again.",
                innerEx.Message);
        }
        _logger.LogWarning("Did not load in the last played session correctly.");
        return false;
    }
}
