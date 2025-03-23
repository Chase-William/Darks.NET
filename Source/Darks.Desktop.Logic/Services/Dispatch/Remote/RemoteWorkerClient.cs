using Darks.Core.Models.Jobs;
using Darks.Desktop.Logic.Args.Jobs;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Dispatch;
using Darks.Dispatch.Args;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Dispatch.Remote;

internal class RemoteWorkerClient : IWorkerClient
{
    private readonly ILogger<RemoteWorkerClient> _logger;
    private readonly IDarksHubConnection _conn;    

    private JobManager? currentJob;
    public JobManager? CurrentJob
    {
        get => currentJob;
        set
        {
            if (currentJob == value)
                return;
            var args = new JobChangedEventArgs(currentJob, value);
            currentJob = value;
            JobChanged?.Invoke(this, args);
        }
    }

    public bool HasJoinedWorkforce { get; private set; }

    public event EventHandler<ExecutableJobEventArgs>? JobStarted;
    public event EventHandler<ExecutableJobEventArgs>? JobCompleted;
    public event EventHandler<ExecutableJobEventArgs>? JobRecovery;
    public event EventHandler<ExecutableJobEventArgs>? JobAbandoned;

    public event EventHandler<JobChangedEventArgs>? JobChanged;

    public RemoteWorkerClient(
        ILogger<RemoteWorkerClient> logger,
        IDarksHubConnection conn,
        WorkerExecutionManager executioner)
    {
        _logger = logger;
        _conn = conn;

        _conn.On<ExecutableJobEventArgs>("StartJob", (args) =>
        {
            executioner.Add(args.Job);
        });
    }
    public async Task<bool> JoinWorkforce()
    {
        try
        {
            await _conn.InvokeAsync("JoinWorkforce");
            return HasJoinedWorkforce = true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Was unable to join the workforce with exception: {ExMsg}", ex.Message);
            return false;
        }
    }

    public async Task<bool> LeaveWorkforce()
    {
        try
        {
            await _conn.InvokeAsync("LeaveWorkforce");
            return !(HasJoinedWorkforce = false);
        }
        catch (Exception ex)
        {
            _logger.LogError("Was unable to leave the workforce with exception: {ExMsg}", ex.Message);
            return false;
        }
    }

    public ImmutableQueue<ExecutableJob> GetQueue()
    {
        throw new NotImplementedException();
    }
}
