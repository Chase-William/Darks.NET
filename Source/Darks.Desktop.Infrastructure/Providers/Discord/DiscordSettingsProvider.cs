using Darks.Core.ViewModels.Discord;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Discord
{
    internal class DiscordSettingsProvider : IDiscordSettingsProvider
    {
        public Task<DiscordSettingsViewModel> GetSettingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
