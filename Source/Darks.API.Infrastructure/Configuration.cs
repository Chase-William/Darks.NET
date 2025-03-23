using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.API.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Darks.API.Infrastructure.Interfaces.Inventory;
using Darks.API.Infrastructure.Repositories.Inventory;
using Darks.API.Infrastructure.Interfaces.Respawn;
using Darks.API.Infrastructure.Repositories.Respawn;
using Darks.API.Infrastructure.Interfaces.TribeLog;
using Darks.API.Infrastructure.Repositories.TribeLog;
using Darks.API.Infrastructure.Interfaces.ParasaurAlarm;
using Darks.API.Infrastructure.Repositories.ParasaurAlarm;
using Darks.API.Infrastructure.Interfaces.Movement;
using Darks.API.Infrastructure.Repositories.Movement;
using Darks.API.Infrastructure.Interfaces.Process;
using Darks.API.Infrastructure.Repositories.Process;
using Darks.API.Infrastructure.Interfaces.GenericKeys;
using Darks.API.Infrastructure.Repositories.GenericKeys;
using Darks.API.Infrastructure.Interfaces.Idle;
using Darks.API.Infrastructure.Repositories.Idle;
using Darks.API.Infrastructure.Interfaces.MainMenu;
using Darks.API.Infrastructure.Repositories.MainMenu;
using Darks.API.Infrastructure.Interfaces.CommandPrompt;
using Darks.API.Infrastructure.Repositories.CommandPrompt;
using Darks.API.Infrastructure.Interfaces.Teleportation;
using Darks.API.Infrastructure.Repositories.Teleportation;
using Darks.API.Infrastructure.Interfaces.Account;
using Darks.API.Infrastructure.Repositories.Account;
using Darks.API.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Darks.API.Infrastructure.Repositories.Resolution;

namespace Darks.API.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureAPIInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<IApplicationDatabaseContext, ApplicationDatabaseContext>(options =>
            {
                options.UseSqlServer(@"Server=GAMINGPC\SQLEXPRESS;Database=Darks-v2;Trusted_Connection=True;");
            });
            services.AddDbContext<IConfigDatabaseContext, ConfigDatabaseContext>(options =>
            {
                options.UseSqlServer(@"Server=GAMINGPC\SQLEXPRESS;Database=Darks-v2;Trusted_Connection=True;");
            });

            services.AddScoped<IGenericKeysRepository, GenericKeysRepository>();
            services.AddScoped<ICommandPromptSettingsRepository, CommandPromptSettingsRepository>();
            services.AddScoped<IMovementSettingsRepository, MovementSettingsRepository>();
            services.AddScoped<IMainMenuConfigRepository, MainMenuConfigRepository>();
            services.AddScoped<IParasaurAlarmConfigRepository, ParasaurAlarmConfigRepository>();
            services.AddScoped<IProcessSettingsRepository, ProcessSettingsRepository>();

            services.AddScoped<IInventorySettingsRepository, InventorySettingsRepository>();
            services.AddScoped<IInventoryConfigRepository, InventoryConfigRepository>();

            services.AddScoped<IRespawnConfigRepository, RespawnConfigRepository>();

            services.AddScoped<ITribeLogConfigRepository, TribeLogConfigRepository>();
            services.AddScoped<ITribeLogSettingsRepository, TribeLogSettingsRepository>();

            services.AddScoped<IIdleSettingsRepository, IdleSettingsRepository>();
            services.AddScoped<ITeleportationSettingsRepository, TeleportationSettingsRepository>();

            services.AddScoped<IMachineRepository, MachineRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IResolutionRepository, ResolutionRepository>();

            return services;
        }
    }
}
