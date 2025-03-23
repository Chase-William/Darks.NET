using Darks.Core.Models.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Interfaces.Auth.Login
{
    public interface IWebLoginService
    {
        Task<bool> LoginAsync(WebLoginRequest login);
    }
}
