using Darks.Core.ViewModels.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface IMainMenuConfigProvider
    {
        Task<MainMenuConfigViewModel> GetConfigAsync();
    }
}
