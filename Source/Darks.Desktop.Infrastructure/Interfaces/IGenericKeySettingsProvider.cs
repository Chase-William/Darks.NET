using Darks.Core.ViewModels.GenericKeys;
using Darks.Core.ViewModels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface IGenericKeySettingsProvider
    {
        Task<GenericKeySettingsViewModel> GetSettingsAsync();
    }
}
