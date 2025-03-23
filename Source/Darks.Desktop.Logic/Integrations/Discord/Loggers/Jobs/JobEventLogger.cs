using Darks.Core.Models.Jobs.Crate;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args.Jobs;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Dispatch.Args;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers.Jobs;
internal class JobEventLogger<T> : Component
    where T : JobManager
{
    IWorkerClient? _workerClient;

    private T? _jobManager;
    protected T? JobManager
    {
        get => _jobManager;
        set
        {
            if (_jobManager == value) return;
            JobManagerChanging?.Invoke();
            _jobManager = value;
            JobManagerChanged?.Invoke();
        }
    }

    protected event Action? JobManagerChanging;
    protected event Action? JobManagerChanged;

    public JobEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IWorkerClientFactory workerClientFactory) : base(discordClient, discordSettingsProvider)
    {
        workerClientFactory.WorkerClientChanged += (_, args) =>
        {
            // Only unsub when not null and are unsubbing from the recorded previous worker
            if (args.Previous == _workerClient && _workerClient is not null)
            {
                _workerClient.JobChanged -= OnJobChanged;                
            }

            if (args.Current is not null)
            {
                args.Current.JobChanged += OnJobChanged;
            }

            _workerClient = args.Current;
        };
    }

    private void OnJobChanged(object? sender, JobChangedEventArgs e)
    {
        if (e.Previous is not null)
        { // Unsub from the previously set if not null
            e.Previous.JobStarted -= OnJobStarted;
            e.Previous.JobCompleted -= OnJobCompleted;
            e.Previous.JobRecovery -= OnJobRecovery;
            e.Previous.JobAbandoned -= OnJobAbandoned;
        }

        if (e.Current is T specificJobManager)
        { // Only notify if the type matches the provided argument as then we can sub
            JobManager = specificJobManager;
            JobManager.JobStarted += OnJobStarted;
            JobManager.JobCompleted += OnJobCompleted;
            JobManager.JobRecovery += OnJobRecovery;
            JobManager.JobAbandoned += OnJobAbandoned;
        }
        else
        { // Otherwise, notify that something other than the supported job manager or null has been set            
            JobManager = null;
        }
    }

    private async void OnJobStarted(object sender, ExecutableJobEventArgs args)
    {
        var settings = await _discordSettingsProvider.GetSettingsAsync();
        var channel = await GetChannel(settings.GlobalJobUpdateChannelId);
        channel?.SendMessageAsync(
            $"""
            JobStarted: {args.Job.Blueprint.GetType().Name} with Id: {args.Job.Blueprint.Id}
            """);
    }

    private async void OnJobCompleted(object sender, ExecutableJobEventArgs args)
    {
        var settings = await _discordSettingsProvider.GetSettingsAsync();
        var channel = await GetChannel(settings.GlobalJobUpdateChannelId);
        channel?.SendMessageAsync(
            $"""
            JobCompleted: {args.Job.Blueprint.GetType().Name} with Id: {args.Job.Blueprint.Id}
            """);
    }

    private async void OnJobRecovery(object sender, ExecutableJobEventArgs args)
    {
        var settings = await _discordSettingsProvider.GetSettingsAsync();
        var channel = await GetChannel(settings.GlobalJobUpdateChannelId);
        channel?.SendMessageAsync(
            $"""
            JobRecovery: {args.Job.Blueprint.GetType().Name} with Id: {args.Job.Blueprint.Id}
            """);
    }

    private async void OnJobAbandoned(object sender, ExecutableJobEventArgs args)
    {
        var settings = await _discordSettingsProvider.GetSettingsAsync();
        var channel = await GetChannel(settings.GlobalJobUpdateChannelId);
        channel?.SendMessageAsync(
            $"""
            JobAbandoned: {args.Job.Blueprint.GetType().Name} with Id: {args.Job.Blueprint.Id}
            """);
    }
}
