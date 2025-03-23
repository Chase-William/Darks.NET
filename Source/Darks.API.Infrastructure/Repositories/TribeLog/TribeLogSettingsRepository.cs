using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.TribeLog;

namespace Darks.API.Infrastructure.Repositories.TribeLog
{
    internal class TribeLogSettingsRepository(IApplicationDatabaseContext dbCtx) : ITribeLogSettingsRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
