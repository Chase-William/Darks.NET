using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.Respawn;

namespace Darks.API.Infrastructure.Repositories.Respawn
{
    internal class RespawnConfigRepository(IApplicationDatabaseContext dbCtx) : IRespawnConfigRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
