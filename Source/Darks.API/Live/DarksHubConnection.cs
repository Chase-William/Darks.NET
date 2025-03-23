using Darks.Core.Models.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Live;

[Authorize]
internal class DarksHubConnection(
    ILogger<DarksHubConnection> logger,
    LaborPoolManager laborPoolManager) : Hub
{
    private readonly ILogger<DarksHubConnection> _logger = logger;
    private readonly LaborPoolManager _laborPoolManager = laborPoolManager;

    public void JoinWorkforce() => _laborPoolManager.Join(Context);
    public void LeaveWorkforce() => _laborPoolManager.Leave(Context);
}

//public override async Task OnConnectedAsync()
//{
//    var machineGroupId = Context.User?.Claims?.SingleOrDefault(c => c.Type == "mid")?.Value;

//    if (machineGroupId is null)
//    { // Cannot hold connection if id not present
//        _logger.LogError("A connection was attempted that did not have a machine group id.");
//        return;
//    }

//    await Groups.AddToGroupAsync(
//        Context.ConnectionId,
//        machineGroupId);                
//}

