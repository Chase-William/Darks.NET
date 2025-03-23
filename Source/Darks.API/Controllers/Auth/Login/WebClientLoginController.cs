using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Darks.API.Logic.Interfaces.Auth;
using Darks.Core.Models.Auth.Login;
using Darks.API.Logic.Interfaces.Auth.Login;

namespace Darks.API.Controllers.Auth.Login
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class WebClientLoginController(
        IWebLoginService authService, 
        IWebTokenProvider tokenProvider) : ControllerBase
    {
        private readonly IWebLoginService _authService = authService;
        private readonly IWebTokenProvider _tokenProvider = tokenProvider;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] WebLoginRequest login)
        {
            if (login == null)
                return BadRequest();

            if (await _authService.LoginAsync(login))
            {
                return Ok(_tokenProvider.GenerateWebClientJWT(login));
            }

            return Unauthorized();
        }
    }
}
