using Darks.Core.Models.Jobs;
using System.Collections.Concurrent;

namespace Darks.API.Test;

/// <summary>
/// A facade for working with jobs.
/// </summary>
interface IManageJobs
{
    /// <summary>
    /// A FIFO queue of jobs ready for execution.
    /// </summary>
    ConcurrentQueue<JobTimeManager> ReadyJobs { get; }
    /// <summary>
    /// A notification that a job is now ready for execution.
    /// </summary>
    event Action<JobBlueprint> JobReady;
}
public class JobManager : IManageJobs
{
    public ConcurrentQueue<JobTimeManager> ReadyJobs => throw new NotImplementedException();

    public event Action<JobBlueprint> JobReady;
}
