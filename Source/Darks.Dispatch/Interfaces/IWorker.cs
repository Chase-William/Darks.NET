
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.Dispatch.Args;

namespace Darks.Dispatch.Interfaces;

public interface IWorker
{
    ImmutableQueue<ExecutableJob> GetQueue();
    //event EventHandler<ExecutableJobEventArgs>? JobStarted;
    //event EventHandler<ExecutableJobEventArgs>? JobCompleted;
    //event EventHandler<ExecutableJobEventArgs>? JobRecovery;
    //event EventHandler<ExecutableJobEventArgs>? JobAbandoned;
}