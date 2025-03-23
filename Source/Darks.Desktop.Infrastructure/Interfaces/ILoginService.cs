using Darks.Core.Common;
using Darks.Core.Models.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface ILoginService
    {
        event Action<string> TokenReceived;
        Task<Result<DesktopLoginResponse>> LoginAsync(DesktopLoginRequest login);
    }
}
