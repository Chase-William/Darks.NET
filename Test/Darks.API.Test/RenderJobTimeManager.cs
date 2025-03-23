using Darks.Core.Models.Jobs.Render;
using Darks.Core.Models.Jobs;
using Timer = System.Timers.Timer;

namespace Darks.API.Test;

public abstract class JobTimeManager(int interval)
{
    protected readonly Timer _timer = new(interval);

    public void StartTimer() => _timer.Start();
    public void StopTimer() => _timer.Stop();

    public abstract JobBlueprint GetJob();
}

public class RenderJobTimeManager : JobTimeManager
{
    private readonly ILogger<RenderJobTimeManager> _logger;

    public RenderJob Job { get; init; }

    public event EventHandler? JobReady;

    public RenderJobTimeManager(
        ILogger<RenderJobTimeManager> logger,
        RenderJob job) : base(3000)
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
