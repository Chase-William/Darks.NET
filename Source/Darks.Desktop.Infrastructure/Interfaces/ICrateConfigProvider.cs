using Darks.Core.ViewModels.Jobs.Crates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface ICrateConfigProvider
    {
        Task<CrateConfigViewModel> GetConfigAsync();
    }
}
