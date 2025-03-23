using Darks.Core.Models.Jobs;
using Darks.Core.Models.Jobs.Crate;
using Darks.Core.Models.Jobs.Crate.Components;
using Darks.Core.Enums;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.Desktop.Logic.Exceptions;
using Darks.Desktop.Logic.Util;

using Monitor = WinUtilities.Monitor;
using Darks.Core.Models;
using Darks.Desktop.Logic.Extensions;
using System.Drawing;
using System.Threading.Channels;
using Darks.Core.ViewModels.Jobs.Crates;

namespace Darks.Desktop.Logic.Services.Jobs
{
    internal class CrateJobManager(
        ILogger<CrateJobManager> logger,
        RespawnManager respawnManager,
        ICrateConfigProvider crateConfigProvider,
        IJobGenericConfigProvider jobGenericConfigProvider,
        InventoryManager inventoryManager,
        CameraController cameraController) : JobManager(respawnManager)
    {
        private readonly ILogger<CrateJobManager> _logger = logger;
        private readonly InventoryManager _inventoryManager = inventoryManager;
        private readonly CameraController _cameraController = cameraController;
        private readonly ICrateConfigProvider _crateConfigProvider = crateConfigProvider;
        private readonly IJobGenericConfigProvider _jobGenericConfigProvider = jobGenericConfigProvider; 

        public event EventHandler<ScreenshotCapturedArgs>? CrateHarvested;
        public event EventHandler<ScreenshotCapturedArgs>? LootDeposited;

        public override async Task Run(CancellationToken cancel = default)
        {
            OnJobStarted();

            var config = await _crateConfigProvider.GetConfigAsync();
            CrateJobBlueprint bp = (CrateJobBlueprint)Job.Blueprint;           

            await HarvestCrates(bp, config, false, cancel); // Harvest all crates

            if (bp.Crates.Length < 5) // Ensure we wait longer before looting again if the beds are likely to be on cooldown still
                await Task.Delay((5 - bp.Crates.Length) * 60000, cancel);
            
            await HarvestCrates(bp, config, true, cancel); // Only havest double spawning crates

            OnJobCompleted();
        }

        private async Task HarvestCrates(
            CrateJobBlueprint bp,
            CrateConfigViewModel config,
            bool filterOnlyDoubleSpawningCrates,
            CancellationToken cancel = default)
        {
            var genericConfig = await _jobGenericConfigProvider.GetConfigAsync();

            foreach (var crate in bp.Crates)
            {
                if (filterOnlyDoubleSpawningCrates && crate.IsDoubleHarvestable || // Only harvest if filtering and is double harvestable
                    !filterOnlyDoubleSpawningCrates) // Run all if not filtering
                    if (await _respawnManager.RespawnAsync(crate.BedName, cancel))                    
                        if (await HarvestCrate(crate, config.CrateScreenshotRect, cancel))
                            await DepositLoot(crate, genericConfig.StructureInfoScreenshotRect, cancel);                    
            }
        }

        private async Task<bool> HarvestCrate(Crate crate, Rect screenshotRect, CancellationToken cancel = default)
        {
            // We are spawned in, however still need to render
            await Task.Delay(crate.LoadDelay, cancel);

            // Initial pivot
            await _cameraController.Pivot(
                crate.GetCrateInventoryInfo.Direction, 
                crate.GetCrateInventoryInfo.InitialPivotDuration,
                cancel);
            // Open using direction based open attempts
            if (await _inventoryManager.OpenAsync(
                crate.GetCrateInventoryInfo.Direction,
                crate.GetCrateInventoryInfo.Increment,
                crate.GetCrateInventoryInfo.Attempts,
                cancel))
            {
                await Task.Delay(1000, cancel);

                CrateHarvested?.Invoke(this, new ScreenshotCapturedArgs((Bitmap)Monitor.GetImage(screenshotRect.ToArea())));                
                await _inventoryManager.TransferAllAsync(Inventory.Self, 1, cancel); // Take all
                await Task.Delay(1000, cancel);
                if (!await _inventoryManager.CloseAsync(Inventory.Other))
                    throw new GameRestartException($"In {GetType().Name}, failed to close inventory when harvesting crate.");
                return true;
            }
            return false;
        }

        private async Task DepositLoot(Crate crate, Rect screenshotRect, CancellationToken cancel = default)
        {
            // Initial pivot
            await _cameraController.Pivot(
                crate.GetDepositInventoryInfo.Direction,
                crate.GetDepositInventoryInfo.InitialPivotDuration,
                cancel);
            // Open using direction based open attempts
            if (await _inventoryManager.OpenAsync(
                crate.GetDepositInventoryInfo.Direction,
                crate.GetDepositInventoryInfo.Increment,
                crate.GetDepositInventoryInfo.Attempts,
                cancel))
            {
                await _inventoryManager.TransferAllAsync(Inventory.Other); // Give all
                await Task.Delay(1000, cancel);
                LootDeposited?.Invoke(this, new ScreenshotCapturedArgs((Bitmap)Monitor.GetImage(screenshotRect.ToArea())));
            }
        }
    }
}
