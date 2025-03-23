using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.Core.Models.GenericKeys;
using Darks.Core.Models.Idle;
using Darks.Core.Models.Inventory;
using Darks.Core.Models.Movement;
using Darks.Core.Models.Process;
using Darks.Core.Models.TribeLog;

namespace Darks.Core.Models.Account
{
    public class MachineBase : Model
    {
        public string DisplayName { get; set; }
        public string DiscordBotToken { get; set; }
        public string Hwid { get; set; }        
    }
}
