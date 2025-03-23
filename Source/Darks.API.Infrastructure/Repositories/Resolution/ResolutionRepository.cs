using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces;
using Darks.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.Resolution
{
    internal class ResolutionRepository(ILogger<ResolutionRepository> logger, IConfigDatabaseContext confDbCtx) : IResolutionRepository
    {
        private readonly ILogger<ResolutionRepository> _logger = logger;
        private readonly IConfigDatabaseContext _confDbCtx = confDbCtx;

        public async Task<Result<Core.Models.Resolution.ResolutionModel>> GetResolutionByWidthAndHeightAsync(int width, int height)
        {
            var result = await _confDbCtx.Resolutions.SingleOrDefaultAsync(res => res.Width == width && res.Height == height);

            if (result is null)
            {
                return Result<Core.Models.Resolution.ResolutionModel>.Failure("Was unable to find a matching resolution the given {width}x{height}.");
            }

            return Result<Core.Models.Resolution.ResolutionModel>.Success(result);
        }
    }
}
