using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.MainMenu
{
    internal class MainMenuConfigRepository(IApplicationDatabaseContext dbCtx) : IMainMenuConfigRepository
    {
        private readonly IApplicationDatabaseContext _dbCtx = dbCtx;
    }
}
