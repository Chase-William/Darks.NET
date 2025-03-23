using Darks.Core.Common;
using Darks.Core.Models.Auth.Login;
using Darks.Desktop.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Services.Auth.Login
{
    internal class LoginService(
        ILogger<LoginService> logger, 
        HttpClient client) : ILoginService
    {
        private readonly ILogger<LoginService> _logger = logger;
        private readonly HttpClient _client = client;

        public event Action<string>? TokenReceived;

        public async Task<Result<DesktopLoginResponse>> LoginAsync(DesktopLoginRequest login)
        {
            try
            {
                var res = await _client.PostAsJsonAsync("auth/login", login);

                if (!res.IsSuccessStatusCode)
                {
                    _logger.LogWarning("The request to login failed with status code: {StatusCode}.", res.StatusCode);
                    return Result<DesktopLoginResponse>.Failure($"The request to login failed with status code: {res.StatusCode}.");
                }

                var result = await res.Content.ReadFromJsonAsync<DesktopLoginResponse>();

                if (result is null)
                {
                    const string msg = "The desktop login response data was deserialized to null.";
                    _logger.LogWarning(msg);
                    return Result<DesktopLoginResponse>.Failure(msg);
                }

                TokenReceived?.Invoke(result.DarksToken);

                return Result<DesktopLoginResponse>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("A login request resulted in the following exception being thrown: {ExMsg}", ex.Message);
                return Result<DesktopLoginResponse>.Failure("The login request threw an error.");
            }
        }
    }
}
