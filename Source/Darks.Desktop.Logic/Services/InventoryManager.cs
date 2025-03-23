using Darks.Core.Enums;
using Darks.Core.Models;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Exceptions;
using Darks.Desktop.Logic.Extensions;
using Darks.Desktop.Logic.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WinUtilities;

using Monitor = WinUtilities.Monitor;

namespace Darks.Desktop.Logic.Services;

public class InventoryManager(
    ILogger<InventoryManager> logger,
    IInventoryConfigProvider configProvider, 
    IInventorySettingsProvider settingsProviders,
    CameraController cameraController)
{
    private readonly ILogger<InventoryManager> _logger = logger;
    private readonly IInventoryConfigProvider _configProvider = configProvider;
    private readonly IInventorySettingsProvider _settingsProviders = settingsProviders;
    private readonly CameraController _cameraController = cameraController;

    public async Task<bool> IsOpenAsync(Inventory who)
    {
        var config = await _configProvider.GetConfigAsync();

        Pixel px = who switch
        {
            Inventory.Self => config.IsSelfInventroyOpenPixel,
            Inventory.Other => config.IsOtherInventroyOpenPixel,
            _ => throw new ArgumentException($"Value {who} is not a valid value for enum {nameof(Inventory)}.")
        };

        return PrimaryMonitor.IsShowing(px);
    }

    /// <summary>
    /// Opens the target inventory returning the resulting state with optional retries.
    /// </summary>
    /// <param name="who"></param>
    /// <param name="retries"></param>
    /// <returns></returns>
    public async Task<bool> OpenAsync(Inventory who, int retries = 0, CancellationToken cancel = default)
    {
        return await ToggleInventory(who, IsOpenAsync, retries, cancel);
    }

    /// <summary>
    /// Pivot the camera in steps to attempt to open an <see cref="Inventory.Other"/> inventory until success or max attempts reached.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="increment"></param>
    /// <param name="attempts"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public async Task<bool> OpenAsync(
        PivotDirection direction,
        int increment = 150,
        int attempts = 3,
        CancellationToken cancel = default)
    {
        for (int i = 0; i < attempts; i++)
        {
            if (await OpenAsync(Inventory.Other, cancel: cancel))
                return true;
            else
                await _cameraController.Pivot(direction, increment, cancel);
        }
        return false;
    }

    /// <summary>
    /// Closes the target inventory returning the resulting state with optional retries.
    /// </summary>
    /// <param name="who"></param>
    /// <param name="retries"></param>
    /// <returns></returns>
    public async Task<bool> CloseAsync(Inventory who, int retries = 0)
    {
        // Inverse the IsOpen function to check if it is closed
        return await ToggleInventory(who, async (who) => !await IsOpenAsync(who), retries);
    }

    public async Task SearchAsync(Inventory who, string what)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Transfer all items to the target inventory and clicks a number of times as it can rarely fail the first time.
    /// </summary>
    /// <param name="receiver"></param>
    /// <param name="clicks"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task TransferAllAsync(Inventory receiver, int clicks = 3, CancellationToken cancel = default)
    {
        var config = await _configProvider.GetConfigAsync();

        var transferBtnPos = receiver switch
        {
            Inventory.Self => config.OtherToSelfTransferBtnPos,
            Inventory.Other => config.SelfToOtherTransferBtnPos,
            _ => throw new ArgumentException($"Value {receiver} is not a valid value for enum {nameof(Inventory)}.")
        };

        for (int i = 0; i < clicks; i++)
        { 
            Mouse.Click(transferBtnPos.ToCoord());
            await Task.Delay(300, cancel);
        }
    }

    public async Task SelectFirstSlot(Inventory who)
    {
        _logger.LogInformation("Selecting the first inventory slot when targting {Target}.", who);
        var config = await _configProvider.GetConfigAsync();
        var pos = who switch
        {
            Inventory.Self => config.SelfFirstSlotPos,
            Inventory.Other => config.OtherFirstSlotPos,
            _ => throw new ArgumentException($"Invalid value for enum {nameof(Inventory)} with value {who}.")
        };

        Mouse.Click(pos.ToCoord());
    }

    private async Task<bool> ToggleInventory(Inventory who, Func<Inventory, Task<bool>> check, int retries = 0, CancellationToken cancel = default)
    {
        var settings = await _settingsProviders.GetSettingsAsync();

        cancel.ThrowIfCancellationRequested();

        var keys = who switch
        {
            Inventory.Self => settings.ToggleSelfInventoryKey.ToKey(),
            Inventory.Other => settings.ToggleOtherInventoryKey.ToKey(),
            _ => throw new ArgumentException($"Value {who} is not a valid value for enum {nameof(Inventory)}.")
        };

        // Check initially to see if inventory is already in the desired state
        if (await check(who))
            return true;

        // Loop until success or max attempts
        for (int attemptNum = -1; attemptNum < retries; attemptNum++)
        {
            cancel.ThrowIfCancellationRequested();
            await Input.SendGame(keys);

            // We need to loop in an async manner to check for state updates while also being cancellable
            await Task.Delay(2500, cancel);
            
            cancel.ThrowIfCancellationRequested();
            // Check in-game state to see if it matches our provided predicate
            if (await check(who))
                return true;
        }
        
        return false;        
    }
}