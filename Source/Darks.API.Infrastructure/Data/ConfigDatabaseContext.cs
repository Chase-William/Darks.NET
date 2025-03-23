using Darks.Core.Models.Account;
using Darks.Core.Models.Configuration;
using Darks.Core.Models.Inventory;
using Darks.Core.Models.MainMenu;
using Darks.Core.Models.ParasaurAlarm;
using Darks.Core.Models.Resolution;
using Darks.Core.Models.Respawn;
using Darks.Core.Models.TribeLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Data
{
    internal class ConfigDatabaseContext(DbContextOptions<ConfigDatabaseContext> options) : DbContext(options), IConfigDatabaseContext
    {
        public DbSet<ResolutionModel> Resolutions { get; set; }
        public DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        public DbSet<InventoryScreenConfigModel> InventoryScreenConfigs { get; set; }
        public DbSet<MainMenuConfigBase> MainMenuScreenConfigs { get; set; }
        public DbSet<ParasaurAlarmConfigModel> ParasaurAlarmScreenConfigs { get; set; }
        public DbSet<RespawnScreenConfigModel> RespawnScreenConfigs { get; set; }
        public DbSet<TribeLogScreenConfig> TribeLogScreenConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryScreenConfigModel>()
                .HasOne(e => e.Resolution)
                .WithOne(e => e.InventoryScreenConfig)
                .HasForeignKey<ResolutionModel>()
                .IsRequired();

            modelBuilder.Entity<ResolutionModel>()
                .HasOne(e => e.InventoryScreenConfig)
                .WithOne(e => e.Resolution)
                .HasForeignKey<InventoryScreenConfigModel>()
                .IsRequired(false);
        }
    }
}
