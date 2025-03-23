using Darks.Desktop.Infrastructure.Interfaces;
using Discord.WebSocket;
using Discord;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Darks.Desktop.Logic.Integrations.Discord;
internal class Component(
    DiscordSocketClient discordClient,
    IDiscordSettingsProvider discordSettingsProvider) 
{
    protected readonly DiscordSocketClient _discordClient = discordClient;
    protected readonly IDiscordSettingsProvider _discordSettingsProvider = discordSettingsProvider;

    protected async Task<ITextChannel?> GetChannel(ulong id)
    {
        if (_discordClient.ConnectionState != ConnectionState.Connected)
            return null;

        var channel = await _discordClient.GetChannelAsync(id) as ITextChannel;

        if (channel is null) // Report error is channel is null
            Log.Logger.Error("Was unable to find channel with the id of {Id}", id);

        return channel;
    }
}
