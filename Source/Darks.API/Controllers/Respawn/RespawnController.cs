using Darks.API.Infrastructure.Interfaces.Respawn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Respawn
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RespawnController(IRespawnConfigRepository repo) : ControllerBase
    {
        private readonly IRespawnConfigRepository _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
