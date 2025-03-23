using Darks.Core.Models.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.Core.Models.Account;
using Darks.Core.Models.Resolution;

namespace Darks.API.Logic.Interfaces.Auth
{
    public interface IDesktopAuthTokenProvider
    {
        public string GenerateDesktopClientJWT(string username, MachineModel machine, ResolutionModel resolution);
    }
}
