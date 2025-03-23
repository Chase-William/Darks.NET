using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services.Jobs;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers.Jobs;
internal class RenderJobEventLogger : JobEventLogger<RenderJobManager>
{
    public RenderJobEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IWorkerClientFactory workerClientFactory)
        : base(discordClient, discordSettingsProvider, workerClientFactory)
    {
        JobManagerChanging += delegate
        {
            if (JobManager is not null)
            {
                JobManager.OnBedRendered -= JobManager_OnBedRendered;
            }
        };

        JobManagerChanged += delegate
        {
            if (JobManager is not null)
            {
                JobManager.OnBedRendered += JobManager_OnBedRendered;
            }
        };
    }

    private async void JobManager_OnBedRendered(object? sender, Args.Jobs.Render.BedRenderedEventArgs e)
    {
        Debug.Assert(JobManager is not null);
        ArgumentNullException.ThrowIfNull(JobManager);

        var channel = await GetChannel(JobManager.Job.Blueprint.UpdateChannelId);
        if (channel is null) return;

        await channel.SendMessageAsync($"Rendered {e.BedName} on {DateTime.Now}.");
    }
}
