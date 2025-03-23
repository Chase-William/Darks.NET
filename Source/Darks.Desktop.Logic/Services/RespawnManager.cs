using Darks.Core.ViewModels.Respawn;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Exceptions;
using Darks.Desktop.Logic.Extensions;
using Darks.Desktop.Logic.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Services;


public class RespawnManager(
    ILogger<RespawnManager> logger,
    IRespawnConfigProvider configProvider,
    InventoryManager inventoryManager,
    GenericKeyController genericKeyController)
{
    private readonly ILogger<RespawnManager> _logger = logger;
    private readonly IRespawnConfigProvider _configProvider = configProvider;
    private readonly InventoryManager _inventoryManager = inventoryManager;
    private readonly GenericKeyController _genericKeyController = genericKeyController;

    public event EventHandler<MissingBedEventArgs>? OnBedMissing;

    public async Task<bool> IsRespawnScreenShowing()
    {
        var config = await _configProvider.GetConfigAsync();
        return PrimaryMonitor.IsShowing(config.IsDeathScreenOpenPixel);
    }

    public async Task<bool> IsFastTravelScreenShowing()
    {
        var config = await _configProvider.GetConfigAsync();
        return PrimaryMonitor.IsShowing(config.IsFastTravelScreenOpenPixel);
    }

    /// <summary>
    /// Spawns the player if already dead and therefore at the spawn/respawn screen, otherwise suicides the player and then respawns it at the provided bed.
    /// </summary>
    /// <param name="nameOfBed"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> RespawnAsync(string nameOfBed, CancellationToken cancel = default)
    {
        _logger.LogInformation("Attempting to respawn to bed named: {NameOfBed}.", nameOfBed);

        //
        // At this point, the spawn screen is visible and we can perform the respawn
        //
        var config = await _configProvider.GetConfigAsync();

        cancel.ThrowIfCancellationRequested();

        if (!await IsRespawnScreenShowing())
        { // Respawn screen is not showing, therefore suicide to get to the respawn screen
            _logger.LogInformation("Respawn screen was not already showing.");
            for (int attempts = 0; attempts < 3; attempts++)
            {
                cancel.ThrowIfCancellationRequested();
                if (await AttemptSuicide(config, cancel: cancel))
                {
                    _logger.LogInformation("Suicide successful on attempt {AttemptNum}.", attempts);
                    break;
                }
                else
                    _logger.LogWarning("Failed to suicide on attempt {AttemptNum}.", attempts);
            }
        }

        _logger.LogInformation("Death screen has been reached.");
        // Wait for a bit as the content on this screen can take a moment to load
        await Task.Delay(3000, CancellationToken.None);

        Mouse.Click(config.DeathScreenSearchbarPos.ToCoord());
        await Task.Delay(250, cancel);

        // At this point, do not cancel as the new owner of control flow would need to clear the searchbar
        Input.SendDown(Key.LCtrl);
        await Task.Delay(100, CancellationToken.None);
        await Input.SendGame(Key.A);
        await Task.Delay(100, CancellationToken.None);
        Input.SendUp(Key.LCtrl);
        await Task.Delay(250, CancellationToken.None);
        await Input.SendGame(Key.Backspace);
        await Task.Delay(2000, CancellationToken.None);
        Input.SendControl(Window.Active, nameOfBed);
        await Task.Delay(1000, CancellationToken.None);
        Mouse.Click(config.SelectBedPixel.Position.ToCoord());
        await Task.Delay(750, CancellationToken.None);
        if (!PrimaryMonitor.IsShowing(config.SelectBedPixel))
        {
            _logger.LogWarning("The bed named: {BedName} was missing and therefore cannot be spawned at.", nameOfBed);
            OnBedMissing?.Invoke(this, new MissingBedEventArgs(nameOfBed));
            return false;
        }
        Mouse.DoubleClick(config.SpawnBtnPos.ToCoord());
        //
        // At this point, the character should be spawning in at the desired bed
        //

        // No need to validate if we left the spawn screen as whatever happens next will find out if we got fucked here
        return true;
    }

    /// <summary>
    /// Uses a bed the player is expected to be looking at to fast travel to a new location.
    /// </summary>
    /// <param name="nameOfBed"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> FastTravelAsync(string nameOfBed)
    {
        _logger.LogInformation("Attempting to fast travel.");
        
        if (!await IsFastTravelScreenShowing())
        { // Fast travel screen wasnt already showing
            for (int attempts = 0; attempts < 10; attempts++)
            { // Attempt to open the bed's fast travel ui a few times
                await _genericKeyController.Use();
                await Task.Delay(1000);
                if (await IsFastTravelScreenShowing())
                    break;
            }
        }

        //
        // At this point, the bed's ui should be showing
        //
        var config = await _configProvider.GetConfigAsync();
        Mouse.Click(config.FastTravelScreenSearchbarPos.ToCoord());
        await Task.Delay(1000);
        Input.SendControl(Window.Active, nameOfBed);
        await Task.Delay(1000);
        Mouse.Click(config.SelectBedPixel.Position.ToCoord());
        await Task.Delay(750);
        if (!PrimaryMonitor.IsShowing(config.SelectBedPixel))
        { // Bed is not showing up, aka is missing
            _logger.LogWarning("When fast traveling, the bed {BedName} was missing.", nameOfBed);
            OnBedMissing?.Invoke(this, new MissingBedEventArgs(nameOfBed));
            return false;
        }
        Mouse.DoubleClick(config.SpawnBtnPos.ToCoord());
        //
        // At this point, the character should be spawning in at the desired bed
        //
        return true;
    }

    private async Task<bool> AttemptSuicide(RespawnConfigViewModel config, int attempts = 3, CancellationToken cancel = default)
    {
        _logger.LogInformation("Attempting suicide.");

        if (!await _inventoryManager.OpenAsync(Core.Enums.Inventory.Self, retries: 3, cancel: cancel))
            throw new GameRestartException($"In {GetType().Name}, failed to open self inventory for suicide.");

        for (int i = -1; i < attempts; i++)
        {
            // Use the inventory manager to select the player's implant for suicide
            await _inventoryManager.SelectFirstSlot(Core.Enums.Inventory.Self);        
            await Task.Delay(7000, cancel); // 5 seconds is required for suicide, however wait additional to ensure safety against lag
            await _genericKeyController.Use(); // Harvest implant to suicide
            await Task.Delay(5000, cancel); // Initial wait for spawn screen to present itself        
            for (int checkNum = 0; checkNum < 10; checkNum++)
            { // Beyond the initial wait, poll to check for spawn screen open
                if (PrimaryMonitor.IsShowing(config.IsDeathScreenOpenPixel))
                {
                    _logger.LogInformation("Suicided successfully.");
                    return true;
                }
                await Task.Delay(500, cancel);
            }
        }
        _logger.LogWarning("Failed to suicide.");
        return false;
    }
}
