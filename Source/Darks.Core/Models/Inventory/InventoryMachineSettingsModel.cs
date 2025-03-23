using Darks.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Inventory
{
    public class InventoryMachineSettingsModel : InventoryMachineSettingsBase
    {
        public MachineBase Machine { get; set; }
    }
}
