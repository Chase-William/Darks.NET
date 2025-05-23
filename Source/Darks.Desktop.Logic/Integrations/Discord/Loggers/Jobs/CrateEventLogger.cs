﻿using Darks.Core.Models.Jobs.Crate;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services.Jobs;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers.Jobs;
internal class CrateEventLogger : JobEventLogger<CrateJobManager>
{
    public CrateEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IWorkerClientFactory workerClientFactory) 
        : base(discordClient, discordSettingsProvider, workerClientFactory)
    {
        JobManagerChanging += delegate
        {
            if (JobManager is not null)
            {
                JobManager.CrateHarvested -= OnCrateHarvested;
                JobManager.LootDeposited -= OnLootDeposited;
            }
        };

        JobManagerChanged += delegate
        {
            if (JobManager is not null)
            {
                JobManager.CrateHarvested += OnCrateHarvested;
                JobManager.LootDeposited += OnLootDeposited;
            }
        };
    }

    private async void OnLootDeposited(object? sender, Args.ScreenshotCapturedArgs e)
    {
        Debug.Assert(JobManager is not null);
        ArgumentNullException.ThrowIfNull(JobManager);

        var channel = await GetChannel(JobManager.Job.Blueprint.UpdateChannelId);
        if (channel is null) return;

        using var memStream = new MemoryStream();
        e.Screenshot.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);

        // TODO: Define a better system for discord tribe log channel ids            
        await channel.SendFileAsync(memStream, "deposit.jpg");
    }

    private async void OnCrateHarvested(object? sender, Args.ScreenshotCapturedArgs e)
    {
        Debug.Assert(JobManager is not null);
        ArgumentNullException.ThrowIfNull(JobManager);

        var channel = await GetChannel(JobManager.Job.Blueprint.UpdateChannelId);
        if (channel is null) return;

        using var memStream = new MemoryStream();
        e.Screenshot.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);

        // TODO: Define a better system for discord tribe log channel ids            
        await channel.SendFileAsync(memStream, "crate.jpg");
    }
}
