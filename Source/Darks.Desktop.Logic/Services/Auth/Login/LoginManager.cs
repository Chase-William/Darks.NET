using Darks.Core.Common;
using Darks.Core.Models.Auth.Login;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Services.Native;
using Darks.Desktop.Logic.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Auth.Login
{
    public class LoginManager(
        ILoginService loginService, 
        ILogger<LoginManager> logger)
    {
        private readonly ILoginService _loginService = loginService;
        private readonly ILogger<LoginManager> _logger = logger;

        public async Task<Result<DesktopLoginResponse>> LoginAsync(string username, string password)
        {
            try
            {
                var hwid = MachineHWIDProvider.GetMyHwid();
                var resolution = PrimaryMonitor.GetResolution();

                var result = await _loginService.LoginAsync(new DesktopLoginRequest
                {
                    Username = username,
                    Password = password,
                    Hwid = hwid,
                    DisplayHeight = resolution.height,
                    DisplayWidth = resolution.width
                });

                if (result.HasError())
                {
                    _logger.LogError("Login attempt call to login infrastructure service returned null.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Login failed with exception: {Ex}", ex.Message);
                return Result<DesktopLoginResponse>.Failure($"Login failed with exception: {ex.Message}");
            }
        }
    }
}
