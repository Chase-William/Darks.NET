using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services;
using Darks.Desktop.Logic.Services.Jobs;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers.Jobs;
internal class BerryFerryEventLogger : JobEventLogger<BerryFerryJobManager>
{
    public BerryFerryEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IWorkerClientFactory workerClientFactory) : base(discordClient, discordSettingsProvider, workerClientFactory)
    {
        JobManagerChanging += delegate
        {
            if (JobManager is not null)
            {
                JobManager.HarvestingCropColumn -= OnPostUpdate;
                JobManager.WalkingToFridges -= OnPostUpdate;
            }
        };

        JobManagerChanged += delegate
        {
            if (JobManager is not null)
            {
                JobManager.HarvestingCropColumn += OnPostUpdate;
                JobManager.WalkingToFridges += OnPostUpdate;
            }
        };
    }

    private async void OnPostUpdate(object? sender, Args.BasicUpdateArgs e)
    {
        Debug.Assert(JobManager is not null);
        ArgumentNullException.ThrowIfNull(JobManager);

        var channel = await GetChannel(JobManager.Job.Blueprint.UpdateChannelId);
        if (channel is null) return;

        await channel.SendMessageAsync(e.Message);
    }
}
