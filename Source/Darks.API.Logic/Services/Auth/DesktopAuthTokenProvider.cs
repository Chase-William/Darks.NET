using Darks.Core.Models.Auth.Login;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Darks.Core.Models.Account;
using Darks.API.Logic.Interfaces.Auth;
using Microsoft.Extensions.Logging;
using Darks.Core.Models.Resolution;

namespace Darks.API.Logic.Services.Auth
{
    internal class DesktopClientTokenProvider(
        ILogger<DesktopClientTokenProvider> logger, 
        IConfiguration config) : IDesktopAuthTokenProvider
    {
        private readonly ILogger<DesktopClientTokenProvider> _logger = logger;
        private readonly IConfiguration _config = config;

        public string GenerateDesktopClientJWT(string username, MachineModel machine, ResolutionModel resolution)
        {
            var t = _config["DesktopClientJWT:Audience"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["DesktopClientJwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, username),
                    new Claim("mid", machine.Id.ToString()),
                    new Claim("rid", resolution.Id.ToString())
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["DesktopClientJWT:Issuer"],
                Audience = _config["DesktopClientJWT:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
