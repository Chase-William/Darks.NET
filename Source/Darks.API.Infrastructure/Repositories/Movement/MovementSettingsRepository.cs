using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.Movement
{
    internal class MovementSettingsRepository(IApplicationDatabaseContext dbCtx) : IMovementSettingsRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
