using Darks.Core.Models.Configuration;
using Darks.Core.Models.Inventory;
using Darks.Core.Models.MainMenu;
using Darks.Core.Models.ParasaurAlarm;
using Darks.Core.Models.Resolution;
using Darks.Core.Models.Respawn;
using Darks.Core.Models.TribeLog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Data
{
    public interface IConfigDatabaseContext
    {
        public DbSet<ResolutionModel> Resolutions { get; }
        public DbSet<ApplicationConfiguration> ApplicationConfigurations { get;}
        public DbSet<InventoryScreenConfigModel> InventoryScreenConfigs { get; }
        public DbSet<MainMenuConfigBase> MainMenuScreenConfigs { get; }
        public DbSet<ParasaurAlarmConfigModel> ParasaurAlarmScreenConfigs { get; }
        public DbSet<RespawnScreenConfigModel> RespawnScreenConfigs { get; }
        public DbSet<TribeLogScreenConfig> TribeLogScreenConfigs { get; }
    }
}
