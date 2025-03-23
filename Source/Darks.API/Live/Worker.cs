using Darks.API.Logic.Services.Dispatch;
using Darks.Dispatch;
using Darks.Dispatch.Args;
using Darks.Dispatch.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Immutable;

namespace Darks.API.Live;

internal class Worker : IWorker
{
    public event EventHandler<ExecutableJobEventArgs>? JobStarted;
    public event EventHandler<ExecutableJobEventArgs>? JobCompleted;
    public event EventHandler<ExecutableJobEventArgs>? JobRecovery;
    public event EventHandler<ExecutableJobEventArgs>? JobAbandoned;

    private readonly ISingleClientProxy _hubClient;

    public Worker(ISingleClientProxy hubClient)
    {
        _hubClient = hubClient;
    }

    public ImmutableQueue<ExecutableJob> GetQueue()
    {
        throw new NotImplementedException();
    }
}
