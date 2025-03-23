using Darks.API.Infrastructure.Interfaces.Process;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Process
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessSettingsController(IProcessSettingsRepository repo) : ControllerBase
    {
        private readonly IProcessSettingsRepository _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
