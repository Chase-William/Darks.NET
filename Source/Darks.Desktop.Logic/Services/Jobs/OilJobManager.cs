using Darks.Desktop.Logic.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.Core.Enums;
using System.Threading.Channels;
using Darks.Desktop.Logic.Args;
using System.Drawing;

using Monitor = WinUtilities.Monitor;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Extensions;

namespace Darks.Desktop.Logic.Services.Jobs;
internal class OilJobManager(
    ILogger<OilJobManager> logger,
    RespawnManager respawnManager,
    InventoryManager inventoryManager,
    CameraController cameraController,
    MovementController movementController,
    IJobGenericConfigProvider jobGenericConfigProvider) : JobManager(respawnManager)
{
    private readonly ILogger<OilJobManager> _logger = logger;
    private const string OilBedNamePrefix = "OIL";

    private readonly InventoryManager _inventoryManager = inventoryManager;
    private readonly CameraController _cameraController = cameraController;
    private readonly MovementController _movementController = movementController;
    private readonly IJobGenericConfigProvider _jobGenericConfigProvider = jobGenericConfigProvider;

    public event EventHandler<ScreenshotCapturedArgs>? PumpHarvested;
    public event EventHandler<ScreenshotCapturedArgs>? OilDeposited;

    public override async Task Run(CancellationToken cancel = default)
    {
        try
        {
            OnJobStarted();          
            for (int i = 0; i < 15; i++)
            {
                if (await _respawnManager.RespawnAsync($"{OilBedNamePrefix} {(i + 1):00}", cancel))
                { // Spawn at oil pump
                    await Task.Delay(15000, cancel); // render
                    if (await TryLootingOilPump(cancel))                    
                        await DepositOilIntoVault(cancel);   
                    // Vault inventories are left open and we use our own implant from it
                }
            }
            OnJobCompleted();
        }
        catch (GameRestartException)
        {
            OnJobRecovery();
            throw;
        }
    }

    private async Task DepositOilIntoVault(CancellationToken cancel = default)
    {        
        await _cameraController.Pivot(PivotDirection.Right, 1000, cancel);
        
        if (await _inventoryManager.OpenAsync(Inventory.Other, cancel: cancel))
        { // Vault is open
            await _inventoryManager.TransferAllAsync(Inventory.Other, cancel: cancel);
            // No need to close inventory as we can use implant from here
            var genericConfig = await _jobGenericConfigProvider.GetConfigAsync();
            OilDeposited?.Invoke(this, new ScreenshotCapturedArgs((Bitmap)Monitor.GetImage(genericConfig.StructureInfoScreenshotRect.ToArea())));
        }
    }

    private async Task<bool> TryLootingOilPump(CancellationToken cancel = default)
    {
        await _movementController.Crouch();
        await Task.Delay(1000, cancel);
        if (await _inventoryManager.OpenAsync(PivotDirection.Down, cancel: cancel))
        {
            // Open oil pump
            await _inventoryManager.TransferAllAsync(Inventory.Self, cancel: cancel);

            var genericConfig = await _jobGenericConfigProvider.GetConfigAsync();
            PumpHarvested?.Invoke(this, new ScreenshotCapturedArgs((Bitmap)Monitor.GetImage(genericConfig.ItemsTransferredScreenshotRect.ToArea())));

            // Close oil pump inventory
            if (!await _inventoryManager.CloseAsync(Inventory.Other, 3))
                throw new GameRestartException($"In {GetType().Name}, failed to close inventory when depositing oil.");                        
            return true;
        }
        return false;
    }
}
