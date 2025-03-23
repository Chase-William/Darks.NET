using Darks.Core.ViewModels.Inventory;
using Darks.Core.ViewModels.Respawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface IRespawnConfigProvider
    {
        Task<RespawnConfigViewModel> GetConfigAsync();
    }
}
