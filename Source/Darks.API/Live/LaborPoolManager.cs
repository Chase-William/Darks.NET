using Microsoft.AspNetCore.SignalR;

namespace Darks.API.Live;

public class LaborPoolManager
{
    private readonly Dictionary<string, LaborPool> _pools = [];

    /// <summary>
    /// Adds a worker to their belonging labor pool.
    /// </summary>
    /// <param name="ctx"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Join(HubCallerContext ctx)
    {
        //    var machineGroupId = Context.User?.Claims?.SingleOrDefault(c => c.Type == "mid")?.Value;

        //    if (machineGroupId is null)
        //    { // Cannot hold connection if id not present
        //        _logger.LogError("A connection was attempted that did not have a machine group id.");
        //        return;
        //    }

        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes a worker from their belonging labor pool.
    /// </summary>
    /// <param name="ctx"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Leave(HubCallerContext ctx)
    {
        throw new NotImplementedException();
    }
}
