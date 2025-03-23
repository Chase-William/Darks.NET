using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Interfaces;
internal interface IDarksHubConnection
{
    bool IsConnected();
    Task Connect();
    Task Disconnect();
    Task InvokeAsync(string methodName);
    Task InvokeAsync<T>(string methodName);
    IDisposable On<T>(string methodName, Action<T> handler);
}
