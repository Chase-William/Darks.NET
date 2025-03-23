using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.Inventory;

namespace Darks.API.Infrastructure.Repositories.Inventory
{
    internal class InventorySettingsRepository(IApplicationDatabaseContext dbCtx) : IInventorySettingsRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
