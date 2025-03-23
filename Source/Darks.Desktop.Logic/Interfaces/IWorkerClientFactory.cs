using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Enums;
using Darks.Desktop.Logic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Interfaces;
internal interface IWorkerClientFactory
{
    IWorkerClient? WorkerClient { get; }
    event EventHandler<WorkerChangedEventArgs>? WorkerClientChanged;
    IWorkerClient CreateWorker(DispatchMode mode);
}
