using Darks.API.Infrastructure.Interfaces;
using Darks.API.Infrastructure.Interfaces.Account;
using Darks.API.Logic.Interfaces.Auth;
using Darks.API.Logic.Interfaces.Auth.Login;
using Darks.Core.Common;
using Darks.Core.Models.Auth.Login;
using Darks.Core.ViewModels.Account;
using Darks.Core.ViewModels.Resolution;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Services.Auth.Login
{
    internal class DesktopLoginService(
        ILogger<DesktopLoginService> logger,
        IUserRepository userRepository,
        IDesktopAuthTokenProvider tokenProvider,
        IResolutionRepository resolutionRepository) : IDesktopLoginService
    {
        private readonly ILogger<DesktopLoginService> _logger = logger;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDesktopAuthTokenProvider _tokenProvider = tokenProvider;
        private readonly IResolutionRepository _resolutionRepository = resolutionRepository;

        public async Task<Result<DesktopLoginResponse>> LoginAsync(DesktopLoginRequest login)
        {
            var user = await _userRepository.GetUserByUsernameAsync(login.Username);
            if (user is null)
            {
                return Result<DesktopLoginResponse>.Failure("User not found.");
            }

            // A user must already have a hwid registered
            if (user.Username == login.Username &&
                user.Password == login.Password &&
                user.Machines.Any(m => m.Hwid == login.Hwid))
            {
                var resolutionResult = await _resolutionRepository.GetResolutionByWidthAndHeightAsync(login.DisplayWidth, login.DisplayHeight);
                if (resolutionResult.HasError())
                {
                    resolutionResult.ErrorMessages.Add($"The provided resolution of {login.DisplayWidth}x{login.DisplayHeight} is unsupported.");
                    return Result<DesktopLoginResponse>.Failure([.. resolutionResult.ErrorMessages]);
                }

                var machine = user.Machines.SingleOrDefault(m => m.Hwid == login.Hwid);             
                if (machine is null)
                {
                    return Result<DesktopLoginResponse>.Failure(
                        $"Was unable to find your machine record associated with your hardware id."    
                    );
                }

                var response = new DesktopLoginResponse {
                    Username = user.Username,
                    Machine = new MachineViewModel(machine),
                    Resolution = new ResolutionViewModel(resolutionResult.Data),
                    DarksToken = _tokenProvider.GenerateDesktopClientJWT(user.Username, machine, resolutionResult.Data)
                    
                };

                return Result<DesktopLoginResponse>.Success(response);
            }
            return Result<DesktopLoginResponse>.Failure("Username and/or password was invalid.");
        }
    }
}
