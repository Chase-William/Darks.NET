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

namespace Darks.Desktop.Logic.Services.Dispatch.Local;
internal class LocalJobManager : IManageJobs
{
    private readonly ILogger<LocalJobManager> _logger;
    private readonly RecurringJobEmitter _emitter;

    private readonly ConcurrentDictionary<Guid, JobExecutionContext> _availableJobs = new();

    ImmutableDictionary<Guid, JobExecutionContext> IManageJobs.AvailableJobs => ImmutableDictionary.CreateRange(_availableJobs);

    public event EventHandler<JobAvailableEventArgs>? JobAvailable;
    
    public LocalJobManager(
        ILogger<LocalJobManager> logger,
        RecurringJobEmitter recurringJobEmitter)
    {
        _logger = logger;
        _emitter = recurringJobEmitter;

        _emitter.JobAvailable += (sender, args) =>
        { // Forward the job to the executioner to handle
            _logger.LogInformation("Adding job {JobType} to the concurrent queue of jobs from the recurring job emitter.", 
                args.Context.Job.Blueprint.GetType().Name);
            _availableJobs.TryAdd(args.Context.Job.UUID, args.Context);
            JobAvailable?.Invoke(this, args);
        };
    }

    public bool TryTake(Guid uuid, out JobExecutionContext? jobCtx)
    {
        _availableJobs.TryRemove(uuid, out jobCtx);
        if (jobCtx is null)
        {
            _logger.LogError(
                "A job was null when getting job associated with GUID {Guid}.", uuid);
            return false;
        }
        return true;
    }
}
