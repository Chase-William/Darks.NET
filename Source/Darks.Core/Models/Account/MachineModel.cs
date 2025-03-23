using Darks.Core.Models.GenericKeys;
using Darks.Core.Models.Idle;
using Darks.Core.Models.Inventory;
using Darks.Core.Models.Movement;
using Darks.Core.Models.TribeLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Account
{
    public class MachineModel : MachineBase
    {
        public GenericKeyMachineSettingsModel GenericKeyMachineSettings { get; set; }
        public IdleSettingsBase IdleMachineSettings { get; set; }
        public InventoryMachineSettingsModel InventoryMachineSettings { get; set; }
        public MovementSettingsModel MovementMachineSettings { get; set; }
        public TribeLogMachineSettings TribeLogMachineSettings { get; set; }
    }
}
