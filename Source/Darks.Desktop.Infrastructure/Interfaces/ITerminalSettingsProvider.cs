using Darks.Core.ViewModels.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface ITerminalSettingsProvider
    {
        Task<TerminalSettingsViewModel> GetSettingsAsync();
    }
}
