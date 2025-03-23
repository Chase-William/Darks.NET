using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.Desktop.Infrastructure;
using Darks.Desktop.Logic.Services;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Desktop.Logic.Services.Auth.Login;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Services.Dispatch;
using Darks.Desktop.Logic.Integrations.Discord;
using Darks.Desktop.Logic.Services.Dispatch.Remote;

namespace Darks.Desktop.Logic
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureDesktopLogicServices(this IServiceCollection services)
        {
            services.ConfigureDesktopInfrastructureServices();

            services.AddSingleton<LoginManager>();
           
            // Services
            services.AddSingleton<TerminalManager>();
            services.AddSingleton<GenericKeyController>();
            services.AddSingleton<IdleStateManager>();
            services.AddSingleton<InventoryManager>();
            services.AddSingleton<MainMenuManager>();
            services.AddSingleton<MovementController>();
            services.AddSingleton<ParasaurAlarmDetector>();
            services.AddSingleton<ProcessManager>();
            services.AddSingleton<RespawnManager>();
            services.AddSingleton<TeleportationManager>();
            services.AddSingleton<TribeLogCapturer>();
            services.AddSingleton<CameraController>();


            // Jobs
            services.AddSingleton<CrateJobManager>();
            services.AddSingleton<SapJobManager>();

            // Integrations
            services.AddSingleton<DiscordConnectionManager>();
            // services.AddSingleton<IClientDispatchService, DispatchDesktopClient>();

            // Factories
            services.AddSingleton<JobManagerFactory>();
            services.AddSingleton<IWorkerClientFactory, WorkerClientFactory>();

            // Worker Service
            // services.AddSingleton<IWorkerService, WorkerService>();
            //services.AddSingleton<IWorkerClient, RemoteWorkerClient>();
            //services.AddSingleton<IExecWorkerClient, RemoteWorkerClient>();

            return services;
        }
    }
}
