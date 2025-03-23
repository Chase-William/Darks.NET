using Darks.Desktop.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;


using Discord.Commands;
using Discord.WebSocket;
using Serilog;
using Microsoft.Extensions.Logging;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args.Jobs.Render;
using Darks.Core.Models.Jobs;
using Darks.Dispatch.Args;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Factories;

namespace Darks.Desktop.Logic.Integrations.Discord;

internal class DiscordConnectionManager
{
    private readonly ILogger<DiscordConnectionManager> _logger;
    private readonly IDiscordSettingsProvider _discordSettingsProvider;
    private readonly IWorkerClientFactory _workerClientFactory;
    private readonly DiscordSocketClient _discordClient;
    private readonly CommandService _commands = new();    

    public DiscordConnectionManager(
        ILogger<DiscordConnectionManager> logger,
        IDiscordSettingsProvider discordSettingsProvider,
        IWorkerClientFactory workerClientFactory,
        DiscordSocketClient discordClient)
    {
        _logger = logger;
        _discordSettingsProvider = discordSettingsProvider;
        _workerClientFactory = workerClientFactory;
        _discordClient = discordClient;

        _discordClient.Log += (msg) =>
        {
            _logger.LogDebug("{DiscordMessage}", msg.Message);
            return Task.CompletedTask;
        };        
    }

    public async Task Connect()
    {
        _logger.LogInformation("Connecting the discord bot.");
        var settings = await _discordSettingsProvider.GetSettingsAsync();
        await _discordClient.LoginAsync(TokenType.Bot, settings.Token);
        await _discordClient.StartAsync();
    }

    public async Task Disconnect()
    {
        _logger.LogInformation("Disconnecting the discord bot.");
        await _discordClient.LogoutAsync();
        await _discordClient.StopAsync();
    }

    public bool IsConnected() => _discordClient.ConnectionState == ConnectionState.Connected;
}
