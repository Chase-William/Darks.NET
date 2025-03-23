using Darks.Desktop.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using NSubstitute;
using Serilog;
using Darks.Core.ViewModels.Inventory;
using Darks.Core.Models;
using Darks.Desktop.Logic.Services;
using Point = Darks.Core.Models.Point;
using Color = Darks.Core.Models.Color;
using Darks.Core.ViewModels.GenericKeys;
using Darks.Core.ViewModels.Respawn;
using Darks.Core.ViewModels.ParasaurAlarm;
using Darks.Core.ViewModels.TribeLog;
using Darks.Core.ViewModels.Terminal;
using System.Configuration;
using Darks.Core.ViewModels.Process;
using Darks.Core.ViewModels.MainMenu;
using Darks.Core.ViewModels.Idle;
using Darks.Core.ViewModels.Discord;
using Darks.Desktop.Logic.Interfaces;
using Darks.Core.Models.Configuration;
using Darks.Desktop.Logic.Services.Dispatch;
using Darks.API.Logic.Services.Auth;
using Darks.Core.Models.Account;
using Darks.Core.Models.Resolution;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Desktop.Logic.Integrations.Discord;
using Darks.Desktop.Logic.Services.Dispatch.Remote;
using Darks.Core.ViewModels.Movement;
using Darks.Core.ViewModels.Camera;
using WinUtilities;
// using Darks.Desktop.Test.Services.Dispatch.Client;

namespace Darks.Desktop.Test;

internal static class Program
{
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
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] ({SourceContext}) {Message}{NewLine}{Exception}")
            .CreateLogger();

        var services = new ServiceCollection();
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog();
        });
       
        services.ConfigureDesktopTest();

        Application.Run(new MainWindow(services.BuildServiceProvider()));
    }
}