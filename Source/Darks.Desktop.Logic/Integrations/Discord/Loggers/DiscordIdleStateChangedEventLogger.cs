using Darks.Desktop.Infrastructure.Interfaces;
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
internal class DiscordIdleStateChangedEventLogger : Component
{
    public DiscordIdleStateChangedEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IdleStateManager idleStateManager) : base(discordClient, discordSettingsProvider)
    {
        idleStateManager.IdleStateChanged += async (sender, args) =>
        {
            var settings = await discordSettingsProvider.GetSettingsAsync();

            var channel = await GetChannel(settings.GlobalJobUpdateChannelId);
            if (channel is null) return;

            await channel.SendMessageAsync($"Idle State Changed with value: {args.State}");
        };
    }
}
