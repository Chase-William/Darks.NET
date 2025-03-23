using Darks.Core.ViewModels.Idle;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Idle
{
    internal class IdleSettingsProvider : IIdleSettingsProvider
    {
        public Task<IdleSettingsViewModel> GetSettingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
