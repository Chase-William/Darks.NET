using Darks.API.Infrastructure.Interfaces.Inventory;
using Darks.API.Logic.Interfaces;
using Darks.Core.Models.Inventory;
using Darks.Core.ViewModels.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Darks.API.Controllers.Inventory
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryConfigController(
        ILogger<InventoryConfigController> logger,
        IInventoryConfigService inventorageConfigService
        ) : ConfigController<InventoryConfigViewModel>(logger, inventorageConfigService)
    {
        private readonly ILogger<InventoryConfigController> _logger = logger;

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            return await base.GetAsync();
        }
    }
}
