using Darks.Core.Models.Jobs;
using Darks.Core.Models.Jobs.Sap;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Jobs
{
    internal class SapJobManager(RespawnManager respawnManager) : JobManager(respawnManager)
    {
        public event EventHandler<BasicUpdateArgs>? SapHarvested;       

        public override Task Run(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

    }
}
