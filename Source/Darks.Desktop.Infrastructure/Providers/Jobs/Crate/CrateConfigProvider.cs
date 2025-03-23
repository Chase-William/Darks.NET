using Darks.Core.ViewModels.Jobs.Crates;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Jobs.Crate
{
    internal class CrateConfigProvider : ICrateConfigProvider
    {
        public Task<CrateConfigViewModel> GetConfigAsync()
        {
            throw new NotImplementedException();
        }
    }
}
