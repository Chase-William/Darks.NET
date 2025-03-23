using Darks.Core.Enums;
using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Exceptions;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace Darks.Desktop.Logic.Services.Jobs;
internal class BerryFerryJobManager(
    ILogger<BerryFerryJobManager> logger,
    RespawnManager respawnManager,    
    MovementController movementController,
    CameraController cameraController,
    InventoryManager inventoryManager) : JobManager(respawnManager)
{
    private readonly ILogger<BerryFerryJobManager> _logger = logger;
    private const string BedNamePrefix = "CROP COLUMN";

    private readonly MovementController _movementController = movementController;
    private readonly CameraController _cameraController = cameraController;
    private readonly InventoryManager _inventoryManager = inventoryManager;

    public event EventHandler<BasicUpdateArgs>? HarvestingCropColumn;
    public event EventHandler<BasicUpdateArgs>? WalkingToFridges;
    public event EventHandler<BasicUpdateArgs>? DepositingBerries;

    public override async Task Run(CancellationToken cancel = default)
    {
        try
        {
            OnJobStarted();
            for (int i = 0; i < 8; i++)
            { // Loop over each bed on the berry ferry
                if (!await _respawnManager.RespawnAsync($"{BedNamePrefix} {i + 1}", cancel))
                    continue; // skip missing bed

                HarvestingCropColumn?.Invoke(this, new BasicUpdateArgs($"Harvesting column {i + 1}."));

                if (i == 0) await Task.Delay(60000, cancel); // Wait a little longer on the first iteration for initial render

                await Task.Delay(15000, cancel); // Wait for render
                await _cameraController.Pivot(PivotDirection.Down, 5000, cancel);
                await _movementController.Walk(MovementDirection.Forward, 475, cancel); // Move to crops

                await HarvestCrops(cancel);
                await WalkToFridges(i, cancel);
                await DepositIntoFridges(cancel);
            }
            OnJobCompleted();
        }
        catch (GameRestartException)
        {
            OnJobRecovery();
            throw;
        }
    }

    private async Task DepositIntoFridges(CancellationToken cancel = default)
    {
        DepositingBerries?.Invoke(this, new BasicUpdateArgs("Depositing berries into fridges."));
        await _cameraController.Pivot(PivotDirection.Up, 1000, cancel);

        for (int i = 0; i < 5; i++)
        { // Always do the first couple iterations as maybe the worker didn't quite walk far enough to the first fridge
            await DepositBerries(cancel);
            await _movementController.Walk(MovementDirection.Right, 325, cancel);
        }

        for (int i = 0; i < 35 && await _inventoryManager.OpenAsync(Inventory.Other, cancel: cancel); i++)
        { // Go until we reach the end where we will be unable to access a fridge or max iteration
            await DepositBerries(cancel);
            await _movementController.Walk(MovementDirection.Right, 325, cancel);
        }

        async Task DepositBerries(CancellationToken cancel = default)
        {
            if (await _inventoryManager.OpenAsync(Inventory.Other, cancel: cancel))
            {
                await _inventoryManager.TransferAllAsync(Inventory.Self, cancel: cancel);
                await Task.Delay(1000, cancel);
                await _inventoryManager.TransferAllAsync(Inventory.Other, cancel: cancel);
                if (!await _inventoryManager.CloseAsync(Inventory.Other, 3))
                    throw new GameRestartException($"In {GetType().Name}, failed to close inventory when depositing berries."); // Failed to close fridge
            }
        }
    }

    private async Task WalkToFridges(int iteration, CancellationToken cancel = default)
    {
        WalkingToFridges?.Invoke(this, new BasicUpdateArgs($"Walking to column {iteration + 1} fridges."));
        await _movementController.Walk(MovementDirection.Left, 12000, cancel);

        int index = 0;

        if (iteration > 3)
        { // Walk to the top floor in this case
            await _movementController.Walk(MovementDirection.Forward, 1000, cancel);
            await _movementController.Walk(MovementDirection.Left, 2500, cancel);
            await _movementController.Walk(MovementDirection.Backward, 6500, cancel);
            await _movementController.Walk(MovementDirection.Right, 2000, cancel);
            // Walk backwards a bit here as the worker will be a little father away than normal
            //  when hitting the code below
            await _movementController.Walk(MovementDirection.Backward, 3000, cancel);
            index = 4;
        }

        // Walk to the correct row on this floor based on the given iteration
        for (; index < iteration + 1; index++)
        {
            // Walk backwards to the next row of fridges
            await _movementController.Walk(MovementDirection.Backward, 5000, cancel);

            if (index == iteration) // Walk sideways over to the fridges if we are at the correct row
                break;
            // Otherwise, walk to the left so that we may go backwards to the next row                
            await _movementController.Walk(MovementDirection.Left, 1500, cancel);
        }

        await _movementController.Walk(MovementDirection.Right, 350, cancel);
    }

    private async Task HarvestCrops(CancellationToken cancel = default)
    {
        for (int i = 0; i < 28; i++)
        {
            if (await _inventoryManager.OpenAsync(Inventory.Other, cancel: cancel))
            {
                await _inventoryManager.TransferAllAsync(Inventory.Self, cancel: cancel);
                if (!await _inventoryManager.CloseAsync(Inventory.Other, 3))
                    throw new GameRestartException($"In {GetType().Name}, failed to close inventory when harvesting crops."); // Cannot close inventory, something is wrong
            }

            await _movementController.Walk(MovementDirection.Forward, 120, cancel);
        }
        // Reach the metal wall as a universal stopping point
        await _movementController.Walk(MovementDirection.Forward, 3000, cancel);
    }
}
