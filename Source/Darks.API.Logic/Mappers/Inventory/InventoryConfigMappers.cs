using Darks.Core.Models.Inventory;
using Darks.Core.ViewModels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Mappers.Inventory
{
    public static class InventoryConfigMappers
    {
        public static InventoryConfigViewModel ToViewModel(this InventoryScreenConfigModel model)
        {
            return new InventoryConfigViewModel(model);
        }
    }
}
