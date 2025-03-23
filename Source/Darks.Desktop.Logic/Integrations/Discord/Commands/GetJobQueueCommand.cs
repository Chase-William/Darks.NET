using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Integrations.Discord.Formatters;
using Darks.Desktop.Logic.Interfaces;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Integrations.Discord.Commands;
internal class GetJobQueueCommand : Command
{
    private readonly IWorkerClientFactory _workerFactory;
    private readonly ExecutableJobFormatter _formatter;

    public GetJobQueueCommand(
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
                .WithName("get-bot-queue")
                .WithDescription("Returns the contents of the local queue if the bot is running."));
    }

    private async void GetCurrentJobCommand_Executed(object? sender, SocketSlashCommand e)
    {
        if (_workerFactory.WorkerClient is null)
        { // If worker is not set, notify there cant be anything in a queue that doesnt exist
            await e.RespondAsync("The bot is not running.");
            return;
        }

        var queue = _workerFactory.WorkerClient.GetQueue();
        if (queue.IsEmpty)
        {
            await e.RespondAsync("Queue is empty.");
            return;
        }

        StringBuilder msgBuilder = new();

        msgBuilder.AppendLine($"Here are the jobs currently in the bots queue: ({queue.Count()})");

        // Iterate over the local queue of jobs
        foreach (var job in queue) // TODO: will get rate limited if large number of jobs
            _formatter.Format(job, msgBuilder);

        await e.RespondAsync(msgBuilder.ToString());
    }
}
