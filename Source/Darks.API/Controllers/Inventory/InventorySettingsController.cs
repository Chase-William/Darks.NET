using Darks.API.Infrastructure.Interfaces.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Inventory
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventorySettingsController(IInventorySettingsRepository repo) : ControllerBase
    {
        private readonly IInventorySettingsRepository _repo = repo;

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
