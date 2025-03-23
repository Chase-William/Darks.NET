using Darks.Core.ViewModels.Camera;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Camera;
internal class CameraSettingsProvider : ICameraSettingsProvider
{
    public Task<CameraSettingsViewModel> GetSettingsAsync()
    {
        throw new NotImplementedException();
    }
}
