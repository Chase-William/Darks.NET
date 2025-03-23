using Darks.API.Infrastructure.Interfaces.TribeLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.TribeLog
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TribeLogConfigController(ITribeLogConfigRepository repo) : ControllerBase
    {
        private readonly ITribeLogConfigRepository _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
