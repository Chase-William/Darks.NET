using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.GenericKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.GenericKeys
{
    internal class GenericKeysRepository(IApplicationDatabaseContext dbCtx) : IGenericKeysRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
