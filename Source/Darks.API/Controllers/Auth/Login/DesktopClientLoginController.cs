using Darks.API.Infrastructure.Interfaces.Account;
using Darks.API.Logic.Interfaces.Auth;
using Darks.API.Logic.Interfaces.Auth.Login;
using Darks.Core.Models.Auth.Login;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Auth.Login
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class DesktopClientLoginController(
        IDesktopLoginService authService,
        IDesktopAuthTokenProvider tokenProvider) : Controller
    {
        private readonly IDesktopLoginService _authService = authService;
        private readonly IDesktopAuthTokenProvider _tokenProvider = tokenProvider;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] DesktopLoginRequest login)
        {
            if (login == null)
                return BadRequest();

            var result = await _authService.LoginAsync(login);

            // Failed to login
            if (result.Data is null)
            {
                return Unauthorized(result.ErrorMessages);
            }           

            return Ok(result.Data);
        }        
    }
}
