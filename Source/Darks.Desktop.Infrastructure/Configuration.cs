using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Infrastructure.Providers.Auth;
using Darks.Desktop.Infrastructure.Providers.Camera;
using Darks.Desktop.Infrastructure.Providers.CommandPrompt;
using Darks.Desktop.Infrastructure.Providers.Configuration;
using Darks.Desktop.Infrastructure.Providers.GenericKeys;
using Darks.Desktop.Infrastructure.Providers.Idle;
using Darks.Desktop.Infrastructure.Providers.Inventory;
using Darks.Desktop.Infrastructure.Providers.Jobs.Crate;
using Darks.Desktop.Infrastructure.Providers.MainMenu;
using Darks.Desktop.Infrastructure.Providers.Movement;
using Darks.Desktop.Infrastructure.Providers.ParasaurAlarm;
using Darks.Desktop.Infrastructure.Providers.Process;
using Darks.Desktop.Infrastructure.Providers.Respawn;
using Darks.Desktop.Infrastructure.Providers.Teleportation;
using Darks.Desktop.Infrastructure.Providers.TribeLog;
using Darks.Desktop.Infrastructure.Services.Auth.Login;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure;

public static class Configuration
{
    public static IServiceCollection ConfigureDesktopInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IDarksTokenProvider, DarksTokenProvider>();
        services.AddHttpClient("DarksHttpClient", client =>
        {
            client.BaseAddress = new Uri("https://localhost:7185/api");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

        }).AddHttpMessageHandler<DarksTokenProvider>();
        services.AddSingleton<ILoginService, LoginService>();        

        services.AddSingleton<IAppConfigurationProvider, AppConfigurationProvider>();        
        services.AddSingleton<IProcessConfigProvider, ProcessConfigProvider>();
        services.AddSingleton<ITerminalSettingsProvider, CommandPromptSettingsProvider>();
        services.AddSingleton<IGenericKeySettingsProvider, GenericKeysSettingsProvider>();
        services.AddSingleton<IMainMenuConfigProvider, MainMenuConfigPrivider>();
        services.AddSingleton<IMovementSettingsProvider, MovementSettingsProvider>();
        services.AddSingleton<IParasaurAlarmConfigProvider, ParasaurAlarmConfigProvider>();
        services.AddSingleton<IRespawnConfigProvider, RespawnConfigProvider>();
        services.AddSingleton<ITribeLogConfigProvider, TribeLogConfigProvider>();
        services.AddSingleton<ITribeLogSettingsProvider, TribeLogSettingsProvider>();
        services.AddSingleton<IInventoryConfigProvider, InventoryConfigProvider>();
        services.AddSingleton<IInventorySettingsProvider, InventorySettingsProvider>();
        services.AddSingleton<IIdleSettingsProvider, IdleSettingsProvider>();
        services.AddSingleton<ITeleportationSettingsProvider, TeleportationSettingsProvider>();
        services.AddSingleton<ICameraSettingsProvider, CameraSettingsProvider>();

        // Jobs
        services.AddSingleton<ICrateConfigProvider, CrateConfigProvider>();

        return services;
    }
}
