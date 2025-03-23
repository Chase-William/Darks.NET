using Darks.Desktop.Infrastructure.Interfaces;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Commands;
internal class Command(
    DiscordSocketClient discordClient,
    IDiscordSettingsProvider discordSettingsProvider) 
    : Component(discordClient, discordSettingsProvider)
{
    protected SocketApplicationCommand? _command;
    protected event EventHandler<SocketSlashCommand>? Executed;

    protected async Task<bool> Register(SlashCommandBuilder builder)
    {
        var settings = await _discordSettingsProvider.GetSettingsAsync();

        var guild = _discordClient.GetGuild(settings.DiscordId);

        try
        {
            _command = await guild.CreateApplicationCommandAsync(builder.Build());

            _discordClient.SlashCommandExecuted += OnSlashCommandExecuted;

            return true;
        }
        catch (HttpException exception)
        {
            // If our command was invalid, we should catch an ApplicationCommandException. This exception contains the path of the error as well as the error message. You can serialize the Error field in the exception to get a visual of where your error is.
            var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);

            // You can send this error somewhere or just print it to the console, for this example we're just going to print it.
            Log.Logger.Error("Was unable to create application command with error: {JsonMsg}", json);
            return false;
        }
    }

    public async Task Unregister()
    {
        if (_command is not null)
        {
            try
            {
                await _command.DeleteAsync();
                _command = null;
            }
            catch (HttpException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                Log.Error("Was unable to remove application command with error: {JsonMsg}", json);
            }
        }
    }

    private Task OnSlashCommandExecuted(SocketSlashCommand arg)
    {
        if (arg.CommandId == _command!.Id)
        { // Only execute on matching command
            Executed?.Invoke(this, arg);            
        }
        return Task.CompletedTask;
    }
}
