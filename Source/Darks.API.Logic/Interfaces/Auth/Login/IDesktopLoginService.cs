using Darks.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.Core.Models.Auth.Login;

namespace Darks.API.Logic.Interfaces.Auth.Login
{
    public interface IDesktopLoginService
    {
        Task<Result<DesktopLoginResponse>> LoginAsync(DesktopLoginRequest login);
    }
}
