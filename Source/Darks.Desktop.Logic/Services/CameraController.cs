using Darks.Core.Enums;
using Darks.Desktop.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Services;
public class CameraController(
    ILogger<CameraController> logger,
    ICameraSettingsProvider settingsProvider)
{
    private readonly ILogger<CameraController> _logger = logger;
    private readonly ICameraSettingsProvider _settingsProvider = settingsProvider;

    public async Task Pivot(PivotDirection direction, int duration, CancellationToken cancel = default)
    {
        if (duration == 0)
            return;

        var settings = await _settingsProvider.GetSettingsAsync();

        var keyAsStr = direction switch
        {
            PivotDirection.Left => settings.Left,
            PivotDirection.Right => settings.Right,
            PivotDirection.Up => settings.Up,
            PivotDirection.Down => settings.Down,
            _ => throw new InvalidEnumArgumentException($"The provided {direction} enum value is not valid {nameof(PivotDirection)} value.")
        };

        if (Enum.TryParse(keyAsStr, out Key key))
        {
            Input.SendControlDown(Window.Active, key);
            try
            {
                await Task.Delay(duration, cancel);
            }
            catch
            {
                throw;
            }
            finally
            { // Ensure keystroke is released
                Input.SendControlUp(Window.Active, key);
            }
        }
    }
}
