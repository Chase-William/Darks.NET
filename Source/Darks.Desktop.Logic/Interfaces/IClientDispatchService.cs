using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Interfaces
{
    public interface IClientDispatchService
    {
        #region Workforce State
        bool HasJoinedWorkforce { get; }
        Task JoinWorkforce();
        Task LeaveWorkforce();
        #endregion

        #region Connections
        Task Connect();
        Task Disconnect();
        #endregion
    }
}
