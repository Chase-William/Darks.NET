using Darks.Core.Models.Jobs.BerryFerry;
using Darks.Core.Models.Jobs.Components;
using Darks.Core.Models.Jobs.Crate.Components;
using Darks.Core.Models.Jobs.Crate;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Services.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.Core.Models.Jobs.Oil;
using Darks.Core.Models.Jobs.Render;

namespace Darks.Desktop.Test.Data;
internal class SeedService(JobManagerFactory jobManagerFactory)
{
    private readonly JobManagerFactory _jobManagerFactory = jobManagerFactory;

    public BerryFerryJobBlueprint GetBerryFerryJob()
        => new()
        {
            ServerName = "2224",
            Id = 1,
            UpdateChannelId = 1294434327605543052
        };

    public BerryFerryJobManager GetBerryFerryJobManagerTestData()
        => (BerryFerryJobManager)_jobManagerFactory.CreateJobManager(new Dispatch.ExecutableJob(GetBerryFerryJob()));

    public CrateJobBlueprint GetCrateJob()
    {
        var getCrate = new HowToGetInventoryInfo
        {
            Direction = Core.Enums.PivotDirection.Down,
            Attempts = 5,
            Increment = 100
        };

        var getVault = new HowToGetInventoryInfo
        {
            Direction = Core.Enums.PivotDirection.Up,
            InitialPivotDuration = 5000,
            Attempts = 5,
            Increment = 1000
        };

        return new CrateJobBlueprint
        {
            ServerName = "2224",
            Id = 2,
            UpdateChannelId = 1291848635994083459,
            Crates = [
                new Crate {
                    BedName = "CHURCH CRATE 01",
                    IsDoubleHarvestable = true,
                    Enabled = true,
                    LoadDelay = 30000,
                    GetCrateInventoryInfo = getCrate,
                    GetDepositInventoryInfo = getVault
                },
                new Crate {
                    BedName = "CHURCH CRATE 02",
                    IsDoubleHarvestable = true,
                    Enabled = true,
                    LoadDelay = 30000,
                    GetCrateInventoryInfo = getCrate,
                    GetDepositInventoryInfo = getVault
                },
                new Crate {
                    BedName = "CENTRAL CRATE 01",
                    IsDoubleHarvestable = true,
                    Enabled = true,
                    LoadDelay = 60000,
                    GetCrateInventoryInfo = getCrate,
                    GetDepositInventoryInfo = getVault
                }
            ]
        };
    }

    public CrateJobManager GetCrateJobManagerTestData()
        => (CrateJobManager)_jobManagerFactory.CreateJobManager(new Dispatch.ExecutableJob(GetCrateJob()));

    public OilJobBlueprint GetOilJob()
        => new()
        {
            ServerName = "2224",
            Id = 3,
            UpdateChannelId = 1294443968464949289
        };

    public OilJobManager GetOilJobManagerTestData()
        => (OilJobManager)_jobManagerFactory.CreateJobManager(new Dispatch.ExecutableJob(GetOilJob()));

    public RenderJobBlueprint GetRenderJob()
        => new()
        {
            BedNames = ["Test #1", "Test #2", "Test #3"],
            ServerName = "2224",
            Id = 4,
            UpdateChannelId = 1291848734086266913
        };

    public RenderJobManager GetRenderJobManagerTestData()
        =>  (RenderJobManager)_jobManagerFactory.CreateJobManager(new Dispatch.ExecutableJob(GetRenderJob()));
}
