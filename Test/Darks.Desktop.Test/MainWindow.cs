using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Integrations.Discord;
using Darks.Desktop.Logic.Integrations.Discord.Commands;
using Darks.Desktop.Logic.Integrations.Discord.Loggers;
using Darks.Desktop.Logic.Integrations.Discord.Loggers.Jobs;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Logic.Services;
using Darks.Desktop.Test.Controls;
using Darks.Desktop.Test.Controls.Job;
using Darks.Desktop.Test.Data;
using Darks.Dispatch.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Darks.Desktop.Test
{
    public partial class MainWindow : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly DiscordConnectionManager _discord;
        private readonly IDarksHubConnection _darksHubConnection;

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _discord = serviceProvider.GetRequiredService<DiscordConnectionManager>();
            _darksHubConnection = serviceProvider.GetRequiredService<IDarksHubConnection>();


            _ = serviceProvider.GetRequiredService<DiscordBedMissingEventLogger>();
            _ = serviceProvider.GetRequiredService<DiscordParasaurAlarmingEventLogger>();
            _ = serviceProvider.GetRequiredService<DiscordIdleStateChangedEventLogger>();
            _ = serviceProvider.GetRequiredService<DiscordTribeLogCapturedEventLogger>();
            _ = serviceProvider.GetRequiredService<DiscordWorkerClientChangedEventLogger>();

            _ = serviceProvider.GetRequiredService<CrateEventLogger>();
            _ = serviceProvider.GetRequiredService<BerryFerryEventLogger>();
            _ = serviceProvider.GetRequiredService<OilJobEventLogger>();
            _ = serviceProvider.GetRequiredService<RenderJobEventLogger>();

            //
            // Default
            //

            defaultTabControl.TabPages.Clear();

            TabPage inventoryPage = new("Inventory");
            inventoryPage.Controls.Add(new InventoryControl(serviceProvider.GetRequiredService<InventoryManager>()));
            defaultTabControl.TabPages.Add(inventoryPage);

            TabPage respawnPage = new("Respawn");
            respawnPage.Controls.Add(new RespawnControl(serviceProvider.GetRequiredService<RespawnManager>()));
            defaultTabControl.TabPages.Add(respawnPage);

            TabPage parasaurAlarmPage = new("Parasaur Alarm");
            parasaurAlarmPage.Controls.Add(new ParasaurAlarmControl(serviceProvider.GetRequiredService<ParasaurAlarmDetector>()));
            defaultTabControl.TabPages.Add(parasaurAlarmPage);

            TabPage tribelogPage = new("Tribe Log");
            tribelogPage.Controls.Add(new TribeLogControl(serviceProvider.GetRequiredService<TribeLogCapturer>()));
            defaultTabControl.TabPages.Add(tribelogPage);

            TabPage terminalPage = new("Terminal");
            terminalPage.Controls.Add(new TerminalControl(serviceProvider.GetRequiredService<TerminalManager>()));
            defaultTabControl.TabPages.Add(terminalPage);

            TabPage processPage = new("Process");
            processPage.Controls.Add(new ProcessControl(serviceProvider.GetRequiredService<ProcessManager>()));
            defaultTabControl.TabPages.Add(processPage);

            TabPage mainMenuPage = new("Main Menu");
            mainMenuPage.Controls.Add(new MainMenuControl(serviceProvider.GetRequiredService<MainMenuManager>()));
            defaultTabControl.TabPages.Add(mainMenuPage);

            TabPage idleStatePage = new("Idle State");
            idleStatePage.Controls.Add(new IdleControl(serviceProvider.GetRequiredService<IdleStateManager>()));
            defaultTabControl.TabPages.Add(idleStatePage);

            TabPage dispatchPage = new("Dispatch");
            dispatchPage.Controls.Add(new DispatchControl(
                serviceProvider.GetRequiredService<IWorkerClientFactory>(),
                serviceProvider.GetRequiredService<RecurringJobEmitter>(),
                serviceProvider.GetRequiredService<SeedService>()));
            defaultTabControl.TabPages.Add(dispatchPage);

            //
            // Jobs
            //
            jobTabControl.TabPages.Clear();
            var seedService = serviceProvider.GetRequiredService<SeedService>();

            TabPage renderJobManager = new("Render Job");
            renderJobManager.Controls.Add(new RenderJobControl(seedService));
            jobTabControl.TabPages.Add(renderJobManager);

            TabPage berryFerryJobManager = new("Berry Ferry Job");
            berryFerryJobManager.Controls.Add(new BerryFerryJobControl(seedService));
            jobTabControl.TabPages.Add(berryFerryJobManager);

            TabPage oilJobManager = new("Oil Job");
            oilJobManager.Controls.Add(new OilJobControl(seedService));
            jobTabControl.TabPages.Add(oilJobManager);

            TabPage crateJobManager = new("Crate Job");
            crateJobManager.Controls.Add(new CrateJobControl(seedService));
            jobTabControl.TabPages.Add(crateJobManager);
        }

        private async void OnDispatchToggleConnectionBtnClicked(object sender, EventArgs e)
        {
            if (_darksHubConnection.IsConnected())
            {
                try
                {
                    await _darksHubConnection.Disconnect();
                    dispatchConnectivityBtn.Text = "Connect";
                }
                catch { }            
            }
            else
            {
                try
                {
                    await _darksHubConnection.Connect();
                    dispatchConnectivityBtn.Text = "Disconnect";
                }
                catch { }
            }
        }

        private async void OnDiscordToggleConnectionBtnClicked(object sender, EventArgs e)
        {
            if (_discord.IsConnected())
            {
                await _serviceProvider.GetRequiredService<GetCurrentJobCommand>().Unregister();
                await _serviceProvider.GetRequiredService<GetJobQueueCommand>().Unregister();
                await _discord.Disconnect();
                discordConnectivityBtn.Text = "Connect";
            }
            else
            {
                await _discord.Connect();
                discordConnectivityBtn.Text = "Disconnect";
                await Task.Delay(2000);
                await _serviceProvider.GetRequiredService<GetCurrentJobCommand>().Register();
                await _serviceProvider.GetRequiredService<GetJobQueueCommand>().Register();
            }
        }

        protected override async void OnClosed(EventArgs e)
        {
            if (_discord.IsConnected())
                await _discord.Disconnect();
            if (_discord.IsConnected())
                await _darksHubConnection.Disconnect();
        }
    }
}
