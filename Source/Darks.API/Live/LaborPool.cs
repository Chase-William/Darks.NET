using Darks.API.Logic.Services.Dispatch;
using Darks.Dispatch.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Darks.API.Live;

public class LaborPool : ILaborPool
{
    private readonly List<IWorker> _workers = [];
    private readonly List<IWorker> _readonlyWorkers;

    IReadOnlyList<IWorker> ILaborPool.Workers => _readonlyWorkers;

    public event EventHandler<WorkerJoinedEventArgs>? WorkerJoined;
    public event EventHandler<WorkerLeftEventArgs>? WorkedLeft;

    public LaborPool()
    {
        _readonlyWorkers = new(_workers);
    }

    public void Join(IWorker client)
    {
        throw new NotImplementedException();
    }

    public void Leave()
    {
        throw new NotImplementedException();
    }
}