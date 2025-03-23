using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers;
internal class DiscordBedMissingEventLogger : Component
{      
    public DiscordBedMissingEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        RespawnManager respawnManager,
        IWorkerClientFactory workerClientFactory) : base(discordClient, discordSettingsProvider)
    {
        respawnManager.OnBedMissing += async (sender, args) =>
        { // Report when a bed is missing
            var settings = await _discordSettingsProvider.GetSettingsAsync();

            var channel = await GetChannel(settings.MissingBedChannelId);

            if (channel is null) return;

            if (workerClientFactory.WorkerClient?.CurrentJob is not null)
            { // If the job manager is unavailable, then the worker is currently idle
                var currentJob = workerClientFactory.WorkerClient.CurrentJob;
                await channel.SendMessageAsync(
                    $"Bed `{args.BedName}` was missing on" +
                    $" server {currentJob.Job.Blueprint.ServerName} for job type {currentJob.GetType().Name}.");
                return;
            }
            // Provide info that it is the idle bed
            await channel.SendMessageAsync($"The idle bed `{args.BedName}` was missing.");            
        };
    }
}
