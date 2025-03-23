using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Inventory
{
    public class InventoryMachineSettingsBase : Model
    {
        public string ToggleSelfInventoryKey { get; set; }
        public string ToggleOtherInventoryKey { get; set; }
    }
}
