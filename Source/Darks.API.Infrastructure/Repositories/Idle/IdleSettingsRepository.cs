using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.Idle;

namespace Darks.API.Infrastructure.Repositories.Idle
{
    internal class IdleSettingsRepository(IApplicationDatabaseContext dbCtx) : IIdleSettingsRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
