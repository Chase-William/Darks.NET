using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Serilog;

using Darks.Desktop.Logic;
using Darks.Desktop.Logic.Services;
using Darks.Desktop.Logic.Services.Auth.Login;
using Darks.Desktop.Controls;

namespace Darks.Desktop
{
    internal static class Program
    {
        private static IServiceProvider? _provider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()                
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog();
            });

            services.ConfigureDesktopLogicServices();          

            _provider = services.BuildServiceProvider();

            Application.Run(new MainWindow(_provider, (res) =>
            {
                // Handle successfully logged in
                Console.WriteLine();
            }));
        }               

        private static void OnToggleStateChanged(bool value)
        {
            Console.WriteLine();
            // var test = provider.GetService<InventoryManager>();
            Console.WriteLine();
        }
    }
}