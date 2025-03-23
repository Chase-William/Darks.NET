using Darks.Core.Models.Jobs;
using Darks.Core.Models.Jobs.BerryFerry;
using Darks.Core.Models.Jobs.Crate;
using Darks.Core.Models.Jobs.Oil;
using Darks.Core.Models.Jobs.Render;
using Darks.Core.Models.Jobs.Sap;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Dispatch;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Factories
{
    internal class JobManagerFactory(IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;       

        public JobManager CreateJobManager(ExecutableJob job)
        {
            JobManager manager = job.Blueprint switch
            {
                SapJobBlueprint => _serviceProvider.GetRequiredService<SapJobManager>(),
                RenderJobBlueprint => _serviceProvider.GetRequiredService<RenderJobManager>(),
                BerryFerryJobBlueprint => _serviceProvider.GetRequiredService<BerryFerryJobManager>(),
                OilJobBlueprint => _serviceProvider.GetRequiredService<OilJobManager>(),
                CrateJobBlueprint => _serviceProvider.GetRequiredService<CrateJobManager>(),
                _ => throw new InvalidOperationException($"Was unable to create Job Manager for {job.Blueprint.GetType().Name}.")
            };

            manager.SetPrivateJob(job);

            return manager;
        }
    }
}
