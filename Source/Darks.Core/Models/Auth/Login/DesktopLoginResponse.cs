using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.Core.ViewModels.Account;
using Darks.Core.ViewModels.Resolution;

namespace Darks.Core.Models.Auth.Login
{
    public class DesktopLoginResponse
    {
        public string Username { get; set; }
        public MachineViewModel Machine { get; set; }
        public ResolutionViewModel Resolution { get; set; }

        public string DarksToken { get; set; }        
    }
}
