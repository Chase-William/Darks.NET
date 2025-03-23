using Darks.Core.ViewModels.Terminal;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.CommandPrompt
{
    internal class CommandPromptSettingsProvider : ITerminalSettingsProvider
    {
        public Task<TerminalSettingsViewModel> GetSettingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
