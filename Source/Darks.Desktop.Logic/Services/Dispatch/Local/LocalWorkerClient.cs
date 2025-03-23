using Darks.Core.Models.Jobs.BerryFerry;
using Darks.Core.Models.Jobs.Oil;
using Darks.Core.Models.Jobs.Render;
using Darks.Desktop.Logic.Args.Jobs;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Dispatch;
using Darks.Dispatch.Args;
using Darks.Dispatch.Factories;
using Darks.Dispatch.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Darks.Desktop.Logic.Services.Dispatch.Local;


internal class LocalWorkerClient(
    ILogger<LocalWorkerClient> logger,
    WorkerExecutionManager executioner,
    IManageJobs jobManager) : IWorkerClient
{
    private readonly ILogger<LocalWorkerClient> _logger = logger;
    private readonly WorkerExecutionManager _executioner = executioner;
    private readonly IManageJobs _jobManager = jobManager;
    /// <summary>
    /// Stores references to jobs that are also added to the executioner's queue just so that we can keep track of the jobs better.
    /// </summary>
    private readonly ConcurrentDictionary<Guid, JobExecutionContext> _jobs = new();

    public bool HasJoinedWorkforce { get; private set; }

    private JobManager? _currentJob;
    public JobManager? CurrentJob
    {
        get => _currentJob;
        set
        {
            if (_currentJob == value) return;
            var prev = _currentJob;
            _currentJob = value;
            JobChanged?.Invoke(this, new JobChangedEventArgs(prev, _currentJob));
        }
    }

    public event EventHandler<JobChangedEventArgs>? JobChanged;
    //public event EventHandler<ExecutableJobEventArgs>? JobStarted;
    //public event EventHandler<ExecutableJobEventArgs>? JobCompleted;
    //public event EventHandler<ExecutableJobEventArgs>? JobRecovery;
    //public event EventHandler<ExecutableJobEventArgs>? JobAbandoned;

    public ImmutableQueue<ExecutableJob> GetQueue() => _executioner.Queue;

    public Task<bool> JoinWorkforce()
    {
        _jobManager.JobAvailable += (sender, args) =>
        { // Move job to executioner when added
            _logger.LogInformation("Adding {JobType} to the executioner from the job manager.", args.Context.Job.Blueprint.GetType().Name);
            if (_jobManager.TryTake(args.Context.Job.UUID, out JobExecutionContext? jobCtx) && jobCtx is not null)
            { // Store it in both as we need to track remote responsibilities here
                _jobs.TryAdd(args.Context.Job.UUID, jobCtx);
                _executioner.Add(jobCtx.Job);
            }
        };

        var keys = _jobManager.AvailableJobs.Select(p => p.Key).ToList(); // make copy
        _logger.LogInformation("Joining the workforce with {Jobs} available.", keys.Count);
        foreach (var key in keys)
        { // Move jobs to execution on joining local workforce
            if (_jobManager.TryTake(key, out JobExecutionContext? jobCtx) && jobCtx is not null)
            {
                _logger.LogInformation(
                    "Adding {JobType} to the executioner from the job manager on startup.",
                    jobCtx.Job.Blueprint.GetType().Name);
                _jobs.TryAdd(key, jobCtx);
                _executioner.Add(jobCtx.Job);
            }
            else
                _logger.LogError("Was unable to take job with Guid {GUID} from job manager.", key);
        }

        _executioner.JobManagerChanged += (sender, args) =>
        { // Wire up notifications for job updates for subscribers
            if (args.Previous is not null)
            {
                args.Previous.JobCompleted -= OnJobCompleted;
            }

            if (args.Current is not null)
            {
                args.Current.JobCompleted += OnJobCompleted;
            }

            CurrentJob = args.Current;
        };

        _executioner.Notify(); // Ensure the executer does something

        return Task.FromResult(true);
    }

    public Task<bool> LeaveWorkforce()
    {        
        return Task.FromResult(true);
    }

    protected virtual void OnJobCompleted(object sender, ExecutableJobEventArgs args)
    {
        if (!_jobs.TryRemove(args.Job.UUID, out JobExecutionContext? ctx))
            _logger.LogError("Was unable to remove job {JobType} with id {Id} from local worker client dictonary on job completed.",
                args.Job.Blueprint.GetType().Name,
                args.Job.Blueprint.Id);

        // Call the completion handler allowing completion operations to occur for this job like restarting the timer for the blueprint
        ctx!.CompletionHandler.Invoke();
    }
}
