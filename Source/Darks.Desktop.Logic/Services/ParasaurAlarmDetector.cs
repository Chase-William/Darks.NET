using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;
using Monitor = WinUtilities.Monitor;

namespace Darks.Desktop.Logic.Services
{
    public class ParasaurAlarmDetector(
        ILogger<ParasaurAlarmDetector> logger,
        IParasaurAlarmConfigProvider configProvider)
    {
        private readonly ILogger<ParasaurAlarmDetector> _logger = logger;
        private readonly IParasaurAlarmConfigProvider _configProvider = configProvider;
    
        public async Task<bool> IsAlarmingAsync()
        {
            // This implementation is different from the norm, check C++
            return false;
            throw new NotImplementedException();
        }

        public async Task<Image> GetAlarmScreenshotAsync()
        {
            var config = await _configProvider.GetConfigAsync();
            return Monitor.GetImage(config.AlarmScreenshotRect.ToArea());
        }
    }
}
