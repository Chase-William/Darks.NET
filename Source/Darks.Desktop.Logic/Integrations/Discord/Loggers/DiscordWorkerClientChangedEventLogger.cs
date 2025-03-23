using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services;
using Darks.Dispatch.Args;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers;
internal class DiscordWorkerClientChangedEventLogger : Component
{
    public DiscordWorkerClientChangedEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IWorkerClientFactory workerClientFactory) : base(discordClient, discordSettingsProvider)
    {
        workerClientFactory.WorkerClientChanged += async (sender, args) =>
        {
            if (args.Previous is not null)
            { // Unsubscribe if we are replacing an existing worker client
                //args.Previous.JobStarted -= OnJobStarted;
                //args.Previous.JobRecovery -= OnJobRecovery;
                //args.Previous.JobCompleted -= OnJobCompleted;
                //args.Previous.JobAbandoned -= OnJobAbandoned;
            }

            if (args.Current is not null)
            {
                //args.Current.JobStarted += OnJobStarted;
                //args.Current.JobRecovery += OnJobRecovery;
                //args.Current.JobCompleted += OnJobCompleted;
                //args.Current.JobAbandoned += OnJobAbandoned;
            }

            var settings = await _discordSettingsProvider.GetSettingsAsync();

            var channel = await GetChannel(settings.WorkerUpdatesChannelId);
            if (channel is null) return;

            await channel.SendMessageAsync(
                $"Dispatch is now operating in {(args.Mode == Enums.DispatchMode.Local ? "Serverless" : "Server-side")} mode.");
        };
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
