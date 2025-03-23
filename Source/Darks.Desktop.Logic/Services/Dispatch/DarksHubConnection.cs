using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Dispatch;
internal class DarksHubConnection(
    ILogger<DarksHubConnection> logger,
    IDarksTokenProvider tokenProvider) : IDarksHubConnection
{
    private readonly ILogger<DarksHubConnection> _logger = logger;
    private readonly HubConnection _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost/dispatch", options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(tokenProvider.DarksToken)!;
            })
            .Build();

    public async Task InvokeAsync(string methodName) => await _hubConnection.InvokeAsync(methodName);
    public async Task InvokeAsync<T>(string methodName) => await _hubConnection.InvokeAsync<T>(methodName);

    public IDisposable On<T>(string methodName, Action<T> handler)
        => _hubConnection.On<T>(methodName, handler);

    public async Task Connect()
    {
        try
        {
            _logger.LogInformation("Connecting the job dispatch service.");
            await _hubConnection.StartAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Was unable to connect to the signaling hub with exception: {Ex}", ex.Message);
            throw;
        }
    }

    public async Task Disconnect()
    {
        try
        {
            _logger.LogInformation("Disconnecting the job dispatch service.");
            await _hubConnection.StopAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Was unable to disconnect from the signaling hub with exception: {Ex}", ex.Message);
            throw;
        }
    }

    public bool IsConnected() => _hubConnection.ConnectionId != null;
}
