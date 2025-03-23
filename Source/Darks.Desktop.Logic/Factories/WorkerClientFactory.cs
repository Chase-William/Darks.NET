using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Enums;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services;
using Darks.Desktop.Logic.Services.Dispatch;
using Darks.Desktop.Logic.Services.Dispatch.Local;
using Darks.Desktop.Logic.Services.Dispatch.Remote;
using Darks.Dispatch.Factories;
using Darks.Dispatch.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Factories;


internal class WorkerClientFactory(IServiceProvider serviceProvider) : IWorkerClientFactory
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public event EventHandler<WorkerChangedEventArgs>? WorkerClientChanged;

    public IWorkerClient? WorkerClient { get; private set; }

    public IWorkerClient CreateWorker(DispatchMode mode)
    {
        IWorkerClient newWorkerClient;
        if (mode == DispatchMode.Local)
        { // Setup for local mode
            newWorkerClient = _serviceProvider.GetRequiredKeyedService<LocalWorkerClient>("Local");
        }
        else
        { // Setup for remote mode
            newWorkerClient = _serviceProvider.GetRequiredKeyedService<RemoteWorkerClient>("Remote");
        }

        WorkerClientChanged?.Invoke(this, new WorkerChangedEventArgs(WorkerClient, newWorkerClient, mode));
        WorkerClient = newWorkerClient;
        return WorkerClient;
    }
}
