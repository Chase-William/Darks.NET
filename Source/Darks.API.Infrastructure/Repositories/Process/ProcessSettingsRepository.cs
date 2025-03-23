using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.Process
{
    internal class ProcessSettingsRepository(IApplicationDatabaseContext dbCtx) : IProcessSettingsRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
