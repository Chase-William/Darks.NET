using Darks.Core.ViewModels.Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface IDiscordSettingsProvider
    {
        Task<DiscordSettingsViewModel> GetSettingsAsync();
    }
}
