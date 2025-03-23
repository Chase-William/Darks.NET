using Darks.API.Infrastructure.Interfaces.GenericKeys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.GenericKeys
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenericKeySettingsController(IGenericKeysRepository repo) : ControllerBase
    {
        private readonly IGenericKeysRepository _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
