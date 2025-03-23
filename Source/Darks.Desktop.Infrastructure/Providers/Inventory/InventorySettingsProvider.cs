using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using Darks.Core.ViewModels.Inventory;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Inventory
{
    internal class InventorySettingsProvider : IInventorySettingsProvider
    {
        Task<InventorySettingsViewModel> IInventorySettingsProvider.GetSettingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
