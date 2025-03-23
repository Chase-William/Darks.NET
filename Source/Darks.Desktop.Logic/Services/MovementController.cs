using Darks.Core.Enums;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Services
{
    public class MovementController(IMovementSettingsProvider settingsProvider)
    {
        private readonly IMovementSettingsProvider _settingsProvider = settingsProvider;

        public async Task Walk(MovementDirection direction, int duration, CancellationToken cancel = default)
        {
            var settings = await _settingsProvider.GetSettingsAsync();

            var keyAsStr = direction switch
            {
                MovementDirection.Forward => settings.MoveForwardKey,
                MovementDirection.Left => settings.MoveLeftKey,
                MovementDirection.Right => settings.MoveRightKey,
                MovementDirection.Backward => settings.MoveBackwardKey,
                _ => throw new InvalidEnumArgumentException($"The provided {direction} enum value is not valid {nameof(MovementDirection)} value.")
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
            else
                throw new InvalidKeyException(keyAsStr);
        }

        public async Task Crouch()
        {
            var settings = await _settingsProvider.GetSettingsAsync();

            if (Enum.TryParse(settings.Crouch, out Key key))
            {
                await Input.SendGame(key);
            }
            else
                throw new InvalidKeyException(settings.Crouch);
        }
    }
}
