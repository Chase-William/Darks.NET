using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using Darks.Core.ViewModels.Inventory;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface IInventoryConfigProvider
    {
        Task<InventoryConfigViewModel> GetConfigAsync();
    }
}
