using Darks.Core.Models.Jobs;
using Darks.Dispatch;
using Darks.Dispatch.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Jobs;


public abstract class JobManager(RespawnManager respawnManager)
{
    protected readonly RespawnManager _respawnManager = respawnManager;    

    public event EventHandler<ExecutableJobEventArgs>? JobStarted;
    public event EventHandler<ExecutableJobEventArgs>? JobCompleted;
    public event EventHandler<ExecutableJobEventArgs>? JobRecovery;
    public event EventHandler<ExecutableJobEventArgs>? JobAbandoned;

    protected void OnJobStarted() => JobStarted?.Invoke(this, new ExecutableJobEventArgs(Job));
    protected void OnJobCompleted() => JobCompleted?.Invoke(this, new ExecutableJobEventArgs(Job));
    protected void OnJobRecovery() => JobRecovery?.Invoke(this, new ExecutableJobEventArgs(Job));
    protected void OnJobAbandoned() => JobAbandoned?.Invoke(this, new ExecutableJobEventArgs(Job));
    
    public ExecutableJob Job { get; private set; }

    /// <summary>
    /// Used internally for <see cref="JobManager"/> creation, do not use.
    /// </summary>
    /// <param name="job"></param>
    internal void SetPrivateJob(ExecutableJob job) => Job = job;

    public abstract Task Run(CancellationToken cancel = default);
}

