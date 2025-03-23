using Darks.API.Infrastructure.Interfaces.Teleportation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Teleportation
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeleportationController(ITeleportationSettingsRepository repo) : ControllerBase
    {
        private readonly ITeleportationSettingsRepository _repo = repo;
    }
}
