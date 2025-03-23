using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.TribeLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.TribeLog
{
    internal class TribeLogConfigRepository(IApplicationDatabaseContext dbCtx) : ITribeLogConfigRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
