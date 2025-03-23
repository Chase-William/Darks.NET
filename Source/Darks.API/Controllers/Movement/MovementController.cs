using Darks.API.Infrastructure.Interfaces.Movement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Movement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController(IMovementSettingsRepository repo) : ControllerBase
    {
        private readonly IMovementSettingsRepository _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
