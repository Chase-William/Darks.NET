using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services;
using Discord.WebSocket;
using Discord;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers;
internal class DiscordParasaurAlarmingEventLogger : Component
{
    public DiscordParasaurAlarmingEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IdleStateManager idleStateManager) : base(discordClient, discordSettingsProvider)
    {
        idleStateManager.ParasaurAlarmDetectedEnemy += async (sender, args) =>
        {
            var settings = await _discordSettingsProvider.GetSettingsAsync();
            var channel = await GetChannel(settings.AlarmChannelId);
            if (channel is null) return;

            using var memStream = new MemoryStream();
            args.Screenshot.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            // TODO: Define a better system for discord tribe log channel ids            
            await channel.SendFileAsync(memStream, "log.jpg");
        };
    }
}
