using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.Inventory;
using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.Inventory;

internal class InventoryConfigRepository(
    ILogger<InventoryConfigRepository> logger,
    IConfigDatabaseContext configDatabaseContext) : IInventoryConfigRepository
{
    private readonly ILogger<InventoryConfigRepository> _logger = logger;
    private readonly IConfigDatabaseContext _configDatabaseContext = configDatabaseContext;

    public async Task<Result<InventoryScreenConfigModel>> GetConfigByResolutionIdAsync(int rid)
    {
        try
        {
            var config = await _configDatabaseContext.InventoryScreenConfigs
                .Include(r => r.Resolution)
                .SingleOrDefaultAsync(r => r.Resolution.Id == rid);

            if (config is null)
            {
                return Result<InventoryScreenConfigModel>
                    .Failure("When fetching the config from the database, null was returned.");
            }

            return Result<InventoryScreenConfigModel>
                .Success(config);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occured when getting a {TypeName} for resolution {ResId} with exception: {ExMsg}", nameof(InventoryScreenConfigModel), rid, ex.Message);
            return Result<InventoryScreenConfigModel>.Failure($"There was an issue acquiring the {nameof(InventoryScreenConfigModel)}.");
        }
    }
}