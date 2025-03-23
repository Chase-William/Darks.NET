using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Loggers;
internal class DiscordTribeLogCapturedEventLogger : Component
{
    public DiscordTribeLogCapturedEventLogger(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IdleStateManager idleStateManager) : base(discordClient, discordSettingsProvider)
    {
        idleStateManager.TribeLogCaptured += async (sender, args) =>
        {// Post updated pictures of tribe log
            var settings = await _discordSettingsProvider.GetSettingsAsync();

            var channel = await GetChannel(settings.Server2224TribeLogChannelId);
            if (channel is null) return;
            
            // TODO: We will want to use the ServerName given as a key to figure out which channel to post to, therefore bots can go to any server and post logs
            using var memStream = new MemoryStream();
            args.Screenshot.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            // TODO: Define a better system for discord tribe log channel ids            
            await channel.SendFileAsync(memStream, "log.jpg");            
        };
    }
}
