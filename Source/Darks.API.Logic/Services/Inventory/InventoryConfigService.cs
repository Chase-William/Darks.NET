using Darks.API.Infrastructure.Interfaces.Inventory;
using Darks.API.Logic.Interfaces;
using Darks.Core.Common;
using Darks.Core.ViewModels.Inventory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.API.Logic.Mappers.Inventory;

namespace Darks.API.Logic.Services.Inventory;

internal class InventoryConfigService(
    ILogger<InventoryConfigService> logger,
    IInventoryConfigRepository inventoryConfigRepository
    ) : IInventoryConfigService
{
    private readonly ILogger<InventoryConfigService> _logger = logger;
    private readonly IInventoryConfigRepository _inventoryConfigRepository = inventoryConfigRepository;
       
    public async Task<Result<InventoryConfigViewModel>> GetViewModelByResolutionIdAsync(int rid)
    {
        var result = await _inventoryConfigRepository.GetConfigByResolutionIdAsync(rid);

        if (result.HasError())
        {
            return Result<InventoryConfigViewModel>.Failure([.. result.ErrorMessages]);
        }

        return Result<InventoryConfigViewModel>.Success(result.Data!.ToViewModel());
    }
}
