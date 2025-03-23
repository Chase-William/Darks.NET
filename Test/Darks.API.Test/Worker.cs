using Darks.Desktop.Logic.Args.Jobs.Out;

namespace Darks.API.Test
{
    /// <summary>
    /// Represents a single online worker.
    /// </summary>
    interface IWorker
    {
        /// <summary>
        /// Fires when this work starts a job.
        /// </summary>
        event EventHandler<JobStartedEventArgs>? JobStarted;
        /// <summary>
        /// Fires when this worker completes a job.
        /// </summary>
        event EventHandler<JobCompletedEventArgs>? JobCompleted;
    }

    internal class Worker : IWorker
    {
        public event EventHandler<JobStartedEventArgs>? JobStarted;
        public event EventHandler<JobCompletedEventArgs>? JobCompleted;
    }
}
