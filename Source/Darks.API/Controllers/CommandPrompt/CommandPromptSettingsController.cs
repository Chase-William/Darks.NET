using Darks.API.Infrastructure.Interfaces.CommandPrompt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.CommandPrompt
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommandPromptSettingsController(ICommandPromptSettingsRepository repo) : ControllerBase
    {
        private readonly ICommandPromptSettingsRepository _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
