using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Darks.API.Test;


[Authorize]
public class DispatchServer : Hub
{
        

    public override async Task OnConnectedAsync()
    {

        // var claims = Context.User.Claims;
        // var t = claims

        var groupName = Context.User?.Claims?.SingleOrDefault(c => c.Type == "mid")?.Value;

        if (groupName is null)
        { // Cannot hold connection if id not present
            Console.WriteLine();
            return;
        }

        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            groupName);

        
        var group = Clients.Group(groupName);

        
    }

    public async Task Ping()
    {
        var claims = Context.User.Claims;

        await Clients.All.SendAsync("Pong");
    }
}
