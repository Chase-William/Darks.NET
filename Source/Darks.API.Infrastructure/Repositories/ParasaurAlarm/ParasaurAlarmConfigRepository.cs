using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.ParasaurAlarm;
using Darks.API.Infrastructure.Repositories.Inventory;
using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using Darks.Core.Models.ParasaurAlarm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.ParasaurAlarm;

internal class ParasaurAlarmConfigRepository(
    ILogger<ParasaurAlarmConfigRepository> logger,
    IConfigDatabaseContext configDatabaseContext) : IParasaurAlarmConfigRepository
{
    private readonly ILogger<ParasaurAlarmConfigRepository> _logger = logger;
    private readonly IConfigDatabaseContext _configDatabaseContext = configDatabaseContext;

    public async Task<Result<ParasaurAlarmConfigModel>> GetConfigByResolutionIdAsync(int rid)
    {
        try
        {
            var config = await _configDatabaseContext.ParasaurAlarmScreenConfigs
            .Include(r => r.Resolution)
            .SingleOrDefaultAsync(r => r.Resolution.Id == rid);

            if (config is null)
            {
                return Result<ParasaurAlarmConfigModel>
                    .Failure("When fetching the config from the database, null was returned.");
            }

            return Result<ParasaurAlarmConfigModel>
                .Success(config);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occured when getting a {TypeName} for resolution {ResId} with exception: {ExMsg}", nameof(ParasaurAlarmConfigModel), rid, ex.Message);
            return Result<ParasaurAlarmConfigModel>.Failure($"There was an issue acquiring the {nameof(ParasaurAlarmConfigModel)}.");
        }        
    }
}
    