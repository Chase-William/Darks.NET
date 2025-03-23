
using Darks.API.Infrastructure.Interfaces.ParasaurAlarm;
using Darks.API.Logic.Interfaces;
using Darks.API.Logic.Mappers.ParasaurAlarm;
using Darks.API.Logic.Services.Inventory;
using Darks.Core.Common;
using Darks.Core.ViewModels.Inventory;
using Darks.Core.ViewModels.ParasaurAlarm;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Services.ParasaurAlarm;

internal class ParasaurAlarmConfigService(
    ILogger<ParasaurAlarmConfigService> logger,
    IParasaurAlarmConfigRepository parasaurAlarmConfigRepository
    ) : IParasaurConfigService
{
    private readonly ILogger<ParasaurAlarmConfigService> _logger = logger;
    private readonly IParasaurAlarmConfigRepository _parasaurAlarmConfigRepository = parasaurAlarmConfigRepository;

    public async Task<Result<ParasaurAlarmConfigViewModel>> GetViewModelByResolutionIdAsync(int rid)
    {
        var result = await _parasaurAlarmConfigRepository.GetConfigByResolutionIdAsync(rid);

        if (result.HasError())
        {
            return Result<ParasaurAlarmConfigViewModel>.Failure([.. result.ErrorMessages]);
        }

        return Result<ParasaurAlarmConfigViewModel>.Success(result.Data!.ToViewModel());
    }
}

