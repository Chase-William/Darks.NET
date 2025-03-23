using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Extensions;
using Darks.Desktop.Logic.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Services
{
    public class TribeLogCapturer(
        ILogger<TribeLogCapturer> logger,
        ITribeLogConfigProvider configProvider, 
        ITribeLogSettingsProvider settingsProvider)
    {
        private const int TribeLogOpenCheckInterval = 500;
        private const int TribeLogOpenCheckTimeout = 60 * 1000;

        private readonly ILogger<TribeLogCapturer> _logger = logger;
        private readonly ITribeLogConfigProvider _configProvider = configProvider;
        private readonly ITribeLogSettingsProvider _settingsProvider = settingsProvider;

        public event EventHandler<ScreenshotCapturedArgs> TribeLogCaptured;
        public event EventHandler<ScreenshotCapturedArgs> ParasaurPingDetected;

        public async Task<bool> IsOpenAsync()
        {
            var config = await _configProvider.GetConfigAsync();
            return PrimaryMonitor.IsShowing(config.IsTribeLogOpenPixel);
        }

        public async Task<bool> OpenAsync()
        {
            _logger.LogInformation("Opening tribe log.");
            if (await IsOpenAsync())
                return true;

            var settings = await _settingsProvider.GetSettingsAsync();

            for (int milliseconds = 0; 
                milliseconds < TribeLogOpenCheckTimeout; 
                milliseconds += TribeLogOpenCheckInterval)
            { // Poll until open or max reached
                await Input.SendGame(settings.ToggleTribeLogKey.ToKey());                
                await Task.Delay(TribeLogOpenCheckInterval);
                if (await IsOpenAsync())
                {
                    await Task.Delay(5000);
                    await ToggleShowOnlyOnlineMembers();
                    await Task.Delay(1000);
                    Mouse.Move(new Coord());
                    return true;
                }
            }

            _logger.LogWarning("Failed to open tribe log.");
            return false;
        }

        public async Task<bool> CloseAsync()
        {
            _logger.LogInformation("Closing tribe log.");
            if (!await IsOpenAsync())
                return true;

            // var settings = await _settingsProvider.GetSettingsAsync();

            await Input.SendGame(Key.Escape);
            for (int checks = 0; checks < 10; checks++)
            { // Poll until closed or max reached
                await Task.Delay(500);
                if (!await IsOpenAsync())
                    return true;
            }

            _logger.LogWarning("Failed to close tribe log.");
            return false;
        }

        private async Task<bool> ToggleShowOnlyOnlineMembers()
        {
            var config = await _configProvider.GetConfigAsync();

            Mouse.Click(config.ToggleOnlineMembersBtnPos.ToCoord());
            return true;
        }

        public async Task<Image> GetTribeLogScreenshot()
        {
            var config = await _configProvider.GetConfigAsync();
            return WinUtilities.Monitor.GetImage(config.TribeLogScreenshotRect.ToArea());
        }
    }
}
