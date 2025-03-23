using Darks.Core.Models.Jobs;
using Darks.Desktop.Logic.Services.Dispatch;
using Darks.Dispatch.Args;
using Darks.Dispatch.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timer = System.Timers.Timer;

namespace Darks.Dispatch.Factories;

public class RecurringJobEmitter(ILogger<RecurringJobEmitter> logger)
{
    private readonly ILogger<RecurringJobEmitter> _logger = logger;
    private readonly Dictionary<JobBlueprint, Timer> _recurringJobs = [];

    public event EventHandler<JobAvailableEventArgs>? JobAvailable;

    public bool Register(JobBlueprint bp, int interval, bool queueImmediately)
    {
        _logger.LogInformation("Registering job {Job} as recurring with interval {Interval} with queue immediately set to {State}.", 
            bp, 
            interval,
            queueImmediately);

        var timer = new Timer(interval);
        timer.Elapsed += delegate
        {
            OnJobReady(bp, interval);
            timer.Stop(); // Stop the timer from repeating
        };

        if (queueImmediately) // Inform others the job is ready right now
            OnJobReady(bp, interval);
        else // If not queueing immedediately, start timer
            timer.Start();

        return _recurringJobs.TryAdd(bp, timer);
    }

    public bool Unregister(JobBlueprint bp)
    {
        _logger.LogInformation("Unregistering job {Job}.", bp);

        if (_recurringJobs.TryGetValue(bp, out Timer? timer))        
            timer?.Stop();
        
        return _recurringJobs.Remove(bp);
    }

    protected virtual void OnJobReady(JobBlueprint bp, int interval)
    {
        var job = new ExecutableJob(bp);

        _logger.LogInformation(
            "Created executable job with guid {Guid} for job {JobType} with id {Id}.",
            job.UUID,
            job.Blueprint.GetType().Name,
            job.Blueprint.Id);

        var jobContext = new JobExecutionContext(
            job,
            () =>
            {
                if (_recurringJobs.TryGetValue(bp, out Timer? timer) && timer is not null)
                {
                    timer.Start();
                    _logger.LogInformation("Started timer in completion handler for job {JobType} with id {Id}.", bp.GetType().Name, bp.Id);
                }
                else
                    _logger.LogWarning("Was unable to restart timer for job type {JobType} with id {Id}. Maybe it was removed.", bp.GetType().Name, bp.Id);
            });

        JobAvailable?.Invoke(this, new JobAvailableEventArgs(jobContext));
    }
}
