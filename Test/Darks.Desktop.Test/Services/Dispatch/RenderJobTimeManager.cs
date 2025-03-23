using Darks.Core.Models.Jobs;
using Darks.Core.Models.Jobs.Render;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timer = System.Timers.Timer;

namespace Darks.Desktop.Test.Services.Dispatch.Jobs;

internal abstract class JobTimeManager(int interval)
{
    protected readonly Timer _timer = new(interval);

    public void StartTimer() => _timer.Start();
    public void StopTimer() => _timer.Stop();

    public abstract JobBlueprint GetJob();
}

internal class RenderJobTimeManager : JobTimeManager
{
    private readonly ILogger<RenderJobTimeManager> _logger;

    public RenderJobBlueprint Job { get; init; }

    public event EventHandler? JobReady;

    public RenderJobTimeManager(
        ILogger<RenderJobTimeManager> logger,
        RenderJobBlueprint job) : base(3000)
    {
        _logger = logger;
        Job = job;
        _timer.Elapsed += delegate
        {
            _logger.LogInformation("Timer elasped for job type of {JobType} with id: {Id}.", Job.GetType().Name, Job.Id);
            JobReady?.Invoke(this, EventArgs.Empty);
        };
    }
    public override JobBlueprint GetJob() => Job;
}
