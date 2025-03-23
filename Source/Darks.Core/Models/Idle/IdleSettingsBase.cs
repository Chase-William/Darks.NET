using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Idle
{
    public class IdleSettingsBase : Model
    {
        public string HomeServerName { get; set; }
        public string IdleBedName { get; set; }
    }
}
