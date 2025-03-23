using Darks.Desktop.Logic.Args.Jobs.Out;

namespace Darks.API.Test;

/// <summary>
/// A facade for working with workers.
/// </summary>
interface IManageWorkers
{
    /// <summary>
    /// A collection of online workers.
    /// </summary>
    List<IWorker> Workers { get; }

    /// <summary>
    /// Fires when a worker joins the work force.
    /// </summary>
    public event EventHandler WorkerJoined;
    /// <summary>
    /// Fires when a worker leaves the work force.
    /// </summary>
    public event EventHandler WorkerLeft;
    /// <summary>
    /// Fires when a worker has announced they have started a job.
    /// </summary>
    public event EventHandler<JobStartedEventArgs> JobStarted;
    /// <summary>
    /// Fires when a worker completes a job.
    /// </summary>
    public event EventHandler<JobCompletedEventArgs> JobCompleted;
}

public class WorkerManager : IManageWorkers
{
    List<IWorker> IManageWorkers.Workers => throw new NotImplementedException();

    public event EventHandler WorkerJoined;
    public event EventHandler WorkerLeft;
    public event EventHandler<JobStartedEventArgs> JobStarted;
    public event EventHandler<JobCompletedEventArgs> JobCompleted;
}
