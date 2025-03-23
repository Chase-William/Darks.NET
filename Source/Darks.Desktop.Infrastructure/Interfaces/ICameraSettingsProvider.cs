﻿using Darks.Core.ViewModels.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces;
public interface ICameraSettingsProvider
{
    Task<CameraSettingsViewModel> GetSettingsAsync();
}
