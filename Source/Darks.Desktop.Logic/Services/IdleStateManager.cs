using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Enums;
using Darks.Desktop.Logic.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace Darks.Desktop.Logic.Services
{
    public class IdleStateManager
    {
        private readonly ILogger<IdleStateManager> _logger;
        private readonly IIdleSettingsProvider _settingsProvider;
        private readonly RespawnManager _respawnManager;
        private readonly ParasaurAlarmDetector _parsaurAlarmDetector;
        private readonly TribeLogCapturer _tribeLogCapturer;

        private readonly System.Timers.Timer _tick = new(15000);

        public event EventHandler<IdleStateUpdateEventArgs>? IdleStateChanged;

        public event EventHandler<ScreenshotCapturedArgs>? TribeLogCaptured;
        public event EventHandler<ScreenshotCapturedArgs>? ParasaurAlarmDetectedEnemy;

        /// <summary>
        /// Fires when an error occurs on the timer's tick that needs to handled.
        /// </summary>
        public event EventHandler? ErrorOnTick;

        public bool InIdle { get; private set; } = false;

        private CancellationToken _cancel;

        public IdleStateManager(
            ILogger<IdleStateManager> logger,
            IIdleSettingsProvider settingsProvider,
            RespawnManager respawnManager,
            ParasaurAlarmDetector parasaurAlarmDetector,
            TribeLogCapturer tribeLogCapturer)
        {
            _logger = logger;
            _settingsProvider = settingsProvider;
            _respawnManager = respawnManager;
            _parsaurAlarmDetector = parasaurAlarmDetector;
            _tribeLogCapturer = tribeLogCapturer;

            _tick.Elapsed += async delegate
            {
                _tick.Stop(); // Stop right away so the timer doesn't elasped during the processing of this tick causing parallel elaspe events

                // Ensure tribe log is already open and is not at death screen
                if (!await tribeLogCapturer.OpenAsync())
                {
                    _logger.LogWarning("Tribe log was not open when idle tick occured and failed to open.");
                    if (!await respawnManager.RespawnAsync((await _settingsProvider.GetSettingsAsync()).IdleBedName, _cancel))
                    {
                        _logger.LogError("Was unable to respawn on idle tick.");                        
                        ErrorOnTick?.Invoke(this, EventArgs.Empty);
                        // throw new GameRestartException($"In {GetType().Name}, failed to respawn on idle tick.");
                    }
                }

                if (await parasaurAlarmDetector.IsAlarmingAsync())
                { // Notify with picture of parasaur if alarm is active
                    _logger.LogInformation("Parasaur alarm detected an enemy.");
                    var ss = (Bitmap)await _parsaurAlarmDetector.GetAlarmScreenshotAsync();
                    ParasaurAlarmDetectedEnemy?.Invoke(this, new ScreenshotCapturedArgs(ss));
                }

                { // Notify tribe log picture update
                    var ss = (Bitmap)await _tribeLogCapturer.GetTribeLogScreenshot();
                    TribeLogCaptured?.Invoke(this, new ScreenshotCapturedArgs(ss));
                }

                _tick.Start();
            };
        }

        public async Task<bool> EnterIdleStateAsync(CancellationToken cancel)
        {
            _cancel = cancel;
            try
            {
                OnIdleStateChanged(IdleState.EnteringIdle);

                var settings = await _settingsProvider.GetSettingsAsync();

                cancel.ThrowIfCancellationRequested(); // Cancellation Checkpoint

                if (!await _respawnManager.RespawnAsync(settings.IdleBedName, cancel))
                { // Was unable to respawn at idle bed
                    _logger.LogError("Was unable to respawn at {BedName} when entering idle.", settings.IdleBedName);
                    return false;
                }

                cancel.ThrowIfCancellationRequested(); // Cancellation Checkpoint

                if (!await _tribeLogCapturer.OpenAsync())
                { // Was unable to open tribe log
                    _logger.LogError("Was unable to open tribe log when entering idle.");
                    return false;
                }

                InIdle = true;
                _tick.Start(); // Start the timer

                OnIdleStateChanged(IdleState.InIdle);
                return InIdle;
            }
            catch (OperationCanceledException)
            {
                OnIdleStateChanged(IdleState.AbortingEntranceIntoIdle);
                _logger.LogInformation("A request to cancel entering idle state was receive and handled.");
            }
            return false;
        }
        
        /// <summary>
        /// Calling this function will disable the timer for polling the screen and attempt to close tribe log.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GameRestartException"></exception>
        public async Task LeaveIdleStateAsync()
        {
            OnIdleStateChanged(IdleState.LeavingIdle);
            _tick.Stop();
            InIdle = false;

            // Close tribe log
            if (!await _tribeLogCapturer.CloseAsync())
            { // Failed to close
                _logger.LogError("Was unable to close tribe log when leaving idle state.");
                throw new GameRestartException($"In {GetType().Name}, failed to close tribe log when leaving idle state.");
            }

            OnIdleStateChanged(IdleState.LeftIdle);
            // Respawn can now be called from elsewhere to begin working            
        }

        protected virtual void OnIdleStateChanged(IdleState state)
            => IdleStateChanged?.Invoke(this, new IdleStateUpdateEventArgs(state));
    }
}
