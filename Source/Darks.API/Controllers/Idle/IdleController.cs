using Darks.API.Infrastructure.Interfaces.Idle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Idle
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdleController(IIdleSettingsRepository repo) : ControllerBase
    {
        private readonly IIdleSettingsRepository _repo = repo;
    }
}
