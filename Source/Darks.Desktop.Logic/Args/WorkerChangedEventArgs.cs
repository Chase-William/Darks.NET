using Darks.Desktop.Logic.Enums;
using Darks.Desktop.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Args;
internal class WorkerChangedEventArgs(
    IWorkerClient? previous,
    IWorkerClient current, 
    DispatchMode mode) : EventArgs
{
    public IWorkerClient? Previous { get; set; } = previous;
    public IWorkerClient Current { get; init; } = current;
    public DispatchMode Mode { get; init; } = mode;
}
