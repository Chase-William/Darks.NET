using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Integrations.Discord.Formatters;
using Darks.Desktop.Logic.Interfaces;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Commands;
internal class GetCurrentJobCommand : Command
{
    private readonly IWorkerClientFactory _workerFactory;
    private readonly ExecutableJobFormatter _formatter;

    public GetCurrentJobCommand(
        DiscordSocketClient discordClient,
        IDiscordSettingsProvider discordSettingsProvider,
        IWorkerClientFactory workerFactory,
        ExecutableJobFormatter formatter) : base(discordClient, discordSettingsProvider)
    {
        _workerFactory = workerFactory;
        _formatter = formatter;
        Executed += GetCurrentJobCommand_Executed;
    }

    public async Task<bool> Register()
    {
        return await Register(
            new SlashCommandBuilder()
                .WithName("get-current-job")
                .WithDescription("Returns the job the bot is actively working on if it exists and the bot is running."));
    }

    private async void GetCurrentJobCommand_Executed(object? sender, SocketSlashCommand e)
    {
        if (_workerFactory.WorkerClient is null)
        { // If worker is not set, notify there cant be anything in a queue that doesnt exist
            await e.RespondAsync("The bot is not running.");
            return;
        }

        var job = _workerFactory.WorkerClient.CurrentJob;
        if (job is null)
        { // Job is null, there are no jobs being completed
            await e.RespondAsync("The bot has no current job.");
            return;
        }

        StringBuilder builder = new();
        builder.AppendLine("Currently processing the following job:");
        _formatter.Format(job.Job, builder);

        await e.RespondAsync(builder.ToString());
    }
}
