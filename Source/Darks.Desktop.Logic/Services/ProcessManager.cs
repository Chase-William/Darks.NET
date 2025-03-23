using Darks.Desktop.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Services;

public class ProcessManager(
    ILogger<ProcessManager> logger,
    IProcessConfigProvider configProvider)
{
    private readonly ILogger<ProcessManager> _logger = logger;
    private readonly IProcessConfigProvider _configProvider = configProvider;

    public async Task LaunchAsync()
    {
        var config = await _configProvider.GetConfigAsync();
            
        try
        {
            var t = Directory.GetCurrentDirectory();
            
            var urlFilePath = Path.Combine(t, config.UrlShortcutFileName);
            if (!File.Exists(urlFilePath))
            {
                _logger.LogInformation("The file at {FilePath} was missing and therefore is being created.", urlFilePath);
                using var file = File.CreateText(urlFilePath);
                file.Write(config.UrlShortcutFileContent);               
            }

            Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = urlFilePath
            });
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occured when attmpting to launch the game with the follow exception: {ExMsg}", ex.Message);
            throw;
        }
    }

    public async Task ExitAsync()
    {
        var config = await _configProvider.GetConfigAsync();
        Process.GetProcessesByName(config.ArkProcessName).FirstOrDefault()?.CloseMainWindow();
    }

    public async Task<bool> IsRunningAsync()
    {
        var config = await _configProvider.GetConfigAsync();
        return Process.GetProcessesByName(config.ArkProcessName).FirstOrDefault() is not null;
    }
}
