using Darks.Core.Models.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Interfaces.Auth
{
    public interface IWebTokenProvider
    {
        public string GenerateWebClientJWT(WebLoginRequest login);
    }
}
