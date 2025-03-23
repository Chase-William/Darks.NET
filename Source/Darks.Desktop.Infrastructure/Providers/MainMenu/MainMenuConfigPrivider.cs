using Darks.Core.ViewModels.MainMenu;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.MainMenu
{
    internal class MainMenuConfigPrivider : IMainMenuConfigProvider
    {
        public Task<MainMenuConfigViewModel> GetConfigAsync()
        {
            throw new NotImplementedException();
        }
    }
}
