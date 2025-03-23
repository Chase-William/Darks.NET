using Darks.Dispatch.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Services.Dispatch;

public class WorkerJoinedEventArgs(IWorker worker) : EventArgs
{
    public IWorker Worker { get; init; } = worker;
}

public class WorkerLeftEventArgs(IWorker worker) : EventArgs
{
    public IWorker Worker { get; init; } = worker;
}

public interface ILaborPool
{
    IReadOnlyList<IWorker> Workers { get; }
    void Join(IWorker worker);
    void Leave();

    event EventHandler<WorkerJoinedEventArgs>? WorkerJoined;
    event EventHandler<WorkerLeftEventArgs>? WorkedLeft;
}