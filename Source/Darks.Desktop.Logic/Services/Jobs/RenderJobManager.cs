using Darks.Core.Models.Jobs;
using Darks.Core.Models.Jobs.Render;
using Darks.Core.Models.Jobs.Sap;
using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Args.Jobs.Render;
using Darks.Desktop.Logic.Exceptions;
using Darks.Dispatch;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Jobs
{
    internal class RenderJobManager(
        ILogger<RenderJobManager> logger,
        RespawnManager respawnManager
        ) : JobManager(respawnManager)
    {
        private readonly ILogger<RenderJobManager> _logger = logger;
        

        public event EventHandler<BedRenderedEventArgs>? OnBedRendered;

        public override async Task Run(CancellationToken cancel = default)
        {
            ArgumentNullException.ThrowIfNull(Job);
            const int ThirtySeconds = 30000;

            try
            {
                OnJobStarted();

                _logger.LogInformation("Starting {JobName}.", Job.Blueprint.GetType().Name);


                if (Job.Blueprint is not RenderJobBlueprint renderBp)
                {
                    _logger.LogError("The job manager of type {JobManagerType} is not compatible with job blueprint type {JobBPType}.",
                        this.GetType().Name,
                        Job.Blueprint.GetType().Name);
                    throw new InvalidOperationException();
                }

                foreach (var bedName in renderBp.BedNames)
                {
                    cancel.ThrowIfCancellationRequested(); // Cancel
                    _logger.LogInformation("Attempting respawn at {BedName}.", bedName);

                    if (!await _respawnManager.RespawnAsync(bedName, cancel))
                    { // Log respawn error and skip render wait
                        _logger.LogWarning("Failed to respawn at {BedName}", bedName);
                        continue;
                    }
                    else
                    {
                        _logger.LogInformation("Successfully respawned at {BedName}.", bedName);
                        OnBedRendered?.Invoke(this, new BedRenderedEventArgs(Job, bedName));
                    }
                    await Task.Delay(ThirtySeconds, cancel);
                }

                _logger.LogInformation("Completed {JobName}.", Job.Blueprint.GetType().Name);

                OnJobCompleted(); // Notify job has completed
            }
            catch (GameRestartException)
            {
                OnJobRecovery(); // Notify an error has occured and is now attempting to recover
                throw;
            }
        }
    }
}
