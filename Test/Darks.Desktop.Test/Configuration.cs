using Darks.API.Logic.Services.Auth;
using Darks.Core.Models.Account;
using Darks.Core.Models.Configuration;
using Darks.Core.Models.Resolution;
using Darks.Core.Models;
using Darks.Core.ViewModels.Camera;
using Darks.Core.ViewModels.Discord;
using Darks.Core.ViewModels.GenericKeys;
using Darks.Core.ViewModels.Idle;
using Darks.Core.ViewModels.Inventory;
using Darks.Core.ViewModels.MainMenu;
using Darks.Core.ViewModels.Movement;
using Darks.Core.ViewModels.ParasaurAlarm;
using Darks.Core.ViewModels.Process;
using Darks.Core.ViewModels.Respawn;
using Darks.Core.ViewModels.Terminal;
using Darks.Core.ViewModels.TribeLog;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Integrations.Discord;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services.Dispatch;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Desktop.Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Darks.Core.Models.Point;
using Color = Darks.Core.Models.Color;
using Darks.Desktop.Logic.Util;
using Darks.Desktop.Test.Data;
using Darks.Dispatch.Factories;
using Darks.Core.ViewModels.Jobs.Crates;
using Darks.Desktop.Logic.Services.Dispatch.Local;
using Darks.Desktop.Logic.Services.Dispatch.Remote;
using Darks.Dispatch.Interfaces;
using Discord.WebSocket;
using Darks.Desktop.Logic.Integrations.Discord.Loggers;
using Darks.Desktop.Logic.Integrations.Discord.Commands;
using Darks.Desktop.Logic.Integrations.Discord.Formatters;
using Darks.Desktop.Logic.Integrations.Discord.Loggers.Jobs;
using Darks.Core.ViewModels.Jobs;

namespace Darks.Desktop.Test;
internal static class Configuration
{
    private static IServiceCollection Configure2560x1440(this IServiceCollection services)
    {
        var inventoryTextColor = new Color(188, 244, 255);

        var inventoryConfigProvider = Substitute.For<IInventoryConfigProvider>();
        inventoryConfigProvider.GetConfigAsync()
            .Returns(new InventoryConfigViewModel
            {
                IsSelfInventroyOpenPixel = new Pixel
                {
                    Position = new Point(410, 195),
                    Color = inventoryTextColor
                },
                IsOtherInventroyOpenPixel = new Pixel
                {
                    Position = new Point(1785, 195),
                    Color = inventoryTextColor
                },
                SelfToOtherTransferBtnPos = new Point
                {
                    X = 490,
                    Y = 260
                },
                OtherToSelfTransferBtnPos = new Point
                {
                    X = 1850,
                    Y = 260
                },
                SelfFirstSlotPos = new Point
                {
                    X = 300,
                    Y = 380
                },
                OtherFirstSlotPos = new Point
                {
                    X = 1660,
                    Y = 370
                }
            });
        services.AddSingleton(inventoryConfigProvider);

        var respawnTextColor = new Color(193, 245, 255);
        var respawnConfigProvider = Substitute.For<IRespawnConfigProvider>();
        respawnConfigProvider.GetConfigAsync()
            .Returns(new RespawnConfigViewModel
            {
                IsDeathScreenOpenPixel = new Pixel
                {
                    Position = new Point(568, 200),
                    Color = respawnTextColor
                },
                IsFastTravelScreenOpenPixel = new Pixel
                {
                    Position = new Point(396, 198),
                    Color = respawnTextColor
                },
                SelectBedPixel = new Pixel
                {
                    Position = new Point(658, 266),
                    Color = new Color(83, 39, 1)
                },
                SpawnBtnPos = new Point(2200, 1280),
                DeathScreenSearchbarPos = new Point(265, 1280),
                FastTravelScreenSearchbarPos = new Point(550, 1280)
            });
        services.AddSingleton(respawnConfigProvider);

        var parasaurAlarmConfigProvider = Substitute.For<IParasaurAlarmConfigProvider>();
        parasaurAlarmConfigProvider.GetConfigAsync()
            .Returns(new ParasaurAlarmConfigViewModel
            {
                AlarmColor = new Color(0, 255, 251),
                AlarmScreenshotRect = new Rect(150, 15, 930, 60)
            });
        services.AddSingleton(parasaurAlarmConfigProvider);

        var tribeLogConfigProvider = Substitute.For<ITribeLogConfigProvider>();
        tribeLogConfigProvider.GetConfigAsync()
            .Returns(new TribeLogConfigViewModel
            {
                IsTribeLogOpenPixel = new Pixel(1057, 194, new Color(193, 245, 255)),
                TribeLogScreenshotRect = new Rect(235, 235, 1555, 1200),
                ToggleOnlineMembersBtnPos = new Point(835, 275)
            });
        services.AddSingleton(tribeLogConfigProvider);

        var mainMenuConfigProvider = Substitute.For<IMainMenuConfigProvider>();
        mainMenuConfigProvider.GetConfigAsync()
            .Returns(new MainMenuConfigViewModel
            {
                JoinLastSessionBtnPixel = new Pixel(1280, 1275, new Color(134, 234, 255)),
                // Position the click to occur on the black part of the button which can be used to validate our state
                HomePageJoinBtnPos = new Point(1250, 1138),
                // Position the click on the white area of the text once it scales up to size on hover
                JoinGameDialogPixel = new Pixel(493, 1043, new Color(255, 255, 255)),
                ServerSearchbarPos = new Point(2200, 260),
                JoinServerBtnPos = new Point(2360, 1255),
                // Position the click over part of the server view holder that becomes dark orange when hovered
                SelectServerPixel = new Pixel(2340, 430, new Color(83, 39, 1)),
                // Position the check to occur on the white of the Official text or horzontal bar
                IsOnServerListingScreenPixel = new Pixel(965, 305, new Color(255, 255, 255))
            });
        services.AddSingleton(mainMenuConfigProvider);

        var crateConfigProvider = Substitute.For<ICrateConfigProvider>();
        crateConfigProvider.GetConfigAsync().Returns(new CrateConfigViewModel
        {
            CrateScreenshotRect = new Rect(1600, 314, 2344, 650)
        });
        services.AddSingleton(crateConfigProvider);

        var jobGenericConfigProvider = Substitute.For<IJobGenericConfigProvider>();
        jobGenericConfigProvider.GetConfigAsync().Returns(new JobGenericConfigViewModel
        {
            ItemsTransferredScreenshotRect = new Rect(0, 1370, 600, 1435),
            StructureInfoScreenshotRect = new Rect(1015, 640, 1535, 790)
        });
        services.AddSingleton(jobGenericConfigProvider);

        return services;
    }

    private static IServiceCollection Configure1920x1080(this IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    public static IServiceCollection ConfigureDesktopTest(this IServiceCollection services)
    {
        // Discord integration
        services.AddSingleton<DiscordSocketClient>();

        // Discord Formatters
        services.AddSingleton<ExecutableJobFormatter>();

        // Discord Event Loggers
        services.AddSingleton<DiscordBedMissingEventLogger>();
        services.AddSingleton<DiscordParasaurAlarmingEventLogger>();
        services.AddSingleton<DiscordIdleStateChangedEventLogger>();
        services.AddSingleton<DiscordTribeLogCapturedEventLogger>();
        services.AddSingleton<DiscordWorkerClientChangedEventLogger>();

        // Job Event Loggers
        services.AddSingleton<CrateEventLogger>();
        services.AddSingleton<BerryFerryEventLogger>();
        services.AddSingleton<OilJobEventLogger>();
        services.AddSingleton<RenderJobEventLogger>();

        // Discord Slash Commands
        services.AddSingleton<GetCurrentJobCommand>();
        services.AddSingleton<GetJobQueueCommand>();

        services.AddSingleton<RecurringJobEmitter>();
        services.AddSingleton<SeedService>();
        services.AddKeyedScoped<LocalWorkerClient>("Local");
        services.AddKeyedScoped<RemoteWorkerClient>("Remote");
        services.AddSingleton<IManageJobs, LocalJobManager>();

        var res = PrimaryMonitor.GetResolution();

        if (res.width == 2560 && res.height == 1440)
            services.Configure2560x1440();
        else if (res.width == 1920 && res.height == 1080)
            services.Configure1920x1080();
        else
            throw new InvalidOperationException("Your resolution is not supported.");
        
        var inventorySettingsProvider = Substitute.For<IInventorySettingsProvider>();
        inventorySettingsProvider.GetSettingsAsync()
            .Returns(new InventorySettingsViewModel
            {
                ToggleSelfInventoryKey = "R",
                ToggleOtherInventoryKey = "F"
            });
        services.AddSingleton(inventorySettingsProvider);
        services.AddSingleton<InventoryManager>();

        var genericKeysProvider = Substitute.For<IGenericKeySettingsProvider>();
        genericKeysProvider.GetSettingsAsync()
            .Returns(new GenericKeySettingsViewModel
            {
                UseKey = "E"
            });
        services.AddSingleton(genericKeysProvider);
        services.AddSingleton<GenericKeyController>();

        
        services.AddSingleton<RespawnManager>();       
        services.AddSingleton<ParasaurAlarmDetector>();
        
        var tribeLogSettingsProvider = Substitute.For<ITribeLogSettingsProvider>();
        tribeLogSettingsProvider.GetSettingsAsync()
            .Returns(new TribeLogSettingsViewModel
            {
                ToggleTribeLogKey = "L"
            });
        services.AddSingleton(tribeLogSettingsProvider);
        services.AddSingleton<TribeLogCapturer>();

        var commandPromptSettingsProvider = Substitute.For<ITerminalSettingsProvider>();
        commandPromptSettingsProvider.GetSettingsAsync()
            .Returns(new TerminalSettingsViewModel
            {
                TerminalToggleKey = "Tab"
            });
        services.AddSingleton(commandPromptSettingsProvider);
        services.AddSingleton<TerminalManager>();

        var processConfigProvider = Substitute.For<IProcessConfigProvider>();
        processConfigProvider.GetConfigAsync()
            .Returns(new ProcessConfigViewModel
            {
                UrlShortcutFileContent =
                """
                [InternetShortcut]
                URL=steam://rungameid/2399830              
                """,
                UrlShortcutFileName = "RunArk.url",
                ArkProcessName = "ArkAscended"
            });
        services.AddSingleton(processConfigProvider);
        services.AddSingleton<ProcessManager>();

        
        services.AddSingleton<MainMenuManager>();

        var idleSettingsProvider = Substitute.For<IIdleSettingsProvider>();
        idleSettingsProvider.GetSettingsAsync()
            .Returns(new IdleSettingsViewModel
            {
                IdleBedName = "XD IDLE BED",
                HomeServerName = "2224"
            });
        services.AddSingleton(idleSettingsProvider);
        services.AddSingleton<IdleStateManager>();

        var movementSettingsProvider = Substitute.For<IMovementSettingsProvider>();
        movementSettingsProvider.GetSettingsAsync().Returns(new MovementSettingsViewModel
        {
            MoveLeftKey = "A",
            MoveRightKey = "D",
            MoveForwardKey = "W",
            MoveBackwardKey = "S",
            Crouch = "C"
        });
        services.AddSingleton(movementSettingsProvider);
        services.AddSingleton<MovementController>();

        var cameraSettingsProvider = Substitute.For<ICameraSettingsProvider>();
        cameraSettingsProvider.GetSettingsAsync().Returns(new CameraSettingsViewModel
        {

            Left = "NumpadLeft",
            Right = "NumpadRight",
            Up = "NumpadUp",
            Down = "NumpadDown"
        });
        services.AddSingleton(cameraSettingsProvider);
        services.AddSingleton<CameraController>();

        var discordSettingsProvider = Substitute.For<IDiscordSettingsProvider>();
        discordSettingsProvider.GetSettingsAsync()
            .Returns(new DiscordSettingsViewModel
            {
                Token = "yea fuck u bud",
                DiscordId = 1269349893995237406,
                DiscordErrorsChannelId = 1291839337968828457,
                WorkerUpdatesChannelId = 1294400881592373311,
                GlobalJobUpdateChannelId = 1291813753259561050,
                MissingBedChannelId = 1291813149271523358,
                AlarmChannelId = 1295157714795761714,
                Server2224TribeLogChannelId = 1291871508561399929
            });
        services.AddSingleton(discordSettingsProvider);
        services.AddSingleton<DiscordConnectionManager>();

        var appConfigProvider = Substitute.For<IAppConfigurationProvider>();
        appConfigProvider.GetConfiguration<IReadonlyDispatcherConfiguration>().Returns(new DispatcherConfiguration
        {
            ConnectionUrl = "https://localhost:7101/test-hub",
            RequestWorkerStartJob = "StartJob",
            RequestWorkerCancelJob = "CancelJob"
        });
        services.AddSingleton(appConfigProvider);

        var aspnetPath = Path.Combine(AppContext.BaseDirectory, "../../../../../Source/Darks.API");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(Path.Combine(aspnetPath, "appsettings.json"))
            .Build();

        #region Jobs
        services.AddScoped<SapJobManager>();
        services.AddScoped<RenderJobManager>();
        services.AddScoped<BerryFerryJobManager>();
        services.AddScoped<OilJobManager>();
        services.AddScoped<CrateJobManager>();
        #endregion

        #region Required For Server SignalR Connection
        var desktopClientTokenProvider = new DesktopClientTokenProvider(
            Substitute.For<ILogger<DesktopClientTokenProvider>>(), configuration);

        var darksToken = desktopClientTokenProvider
            .GenerateDesktopClientJWT(
                "test-user",
                new MachineModel
                {
                    Id = 5
                },
                new ResolutionModel
                {
                    Id = 10
                });

        var tokenProvider = Substitute.For<IDarksTokenProvider>();
        tokenProvider.DarksToken.Returns(darksToken);
        services.AddSingleton(tokenProvider);
        #endregion

        services.AddSingleton<IDarksHubConnection, DarksHubConnection>();
        services.AddSingleton<WorkerExecutionManager>();

        // Factories
        services.AddSingleton<JobManagerFactory>();
        services.AddSingleton<IWorkerClientFactory, WorkerClientFactory>();

        return services;
    }
}
