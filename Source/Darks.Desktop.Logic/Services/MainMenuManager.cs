using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Args;
using Darks.Desktop.Logic.Extensions;
using Darks.Desktop.Logic.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Services
{
    public class MainMenuManager(
        ILogger<MainMenuManager> logger,
        IMainMenuConfigProvider configProvider,
        TerminalManager terminalManager)
    {
        private readonly ILogger<MainMenuManager> _logger = logger;
        private readonly IMainMenuConfigProvider _configProvider = configProvider;
        private readonly TerminalManager _terminalManager = terminalManager;

        /// <summary>
        /// Invoked when a server fails to show up when queried on the server listening screen.
        /// </summary>
        public event EventHandler<ServerMissingEventArgs> OnServerMissing;

        public async Task<bool> IsHomeScreenShowing()
        {
            var config = await _configProvider.GetConfigAsync();
            return PrimaryMonitor.IsShowing(config.JoinLastSessionBtnPixel);
        }

        public async Task ExitToMainMenu()
        {
            await terminalManager.Write("DISCONNECT");
        }

        public async Task<bool> JoinServer(string serverName)
        {
            var config = await _configProvider.GetConfigAsync();

            if (!await IsHomeScreenShowing())
            {
                _logger.LogWarning("Attempted to join server {Server} but found the home page was not showing.", serverName);
                return false;
            }                

            Mouse.Click(config.HomePageJoinBtnPos.ToCoord());
            await Task.Delay(1000);
            Mouse.Move(config.JoinGameDialogPixel.Position.ToCoord());
            await Task.Delay(3000); // IMPORTANT -- Allow animation to play until finished before sampling
            if (!PrimaryMonitor.IsShowing(config.JoinGameDialogPixel))
            {
                _logger.LogWarning("Attempted to join server {Server} but was unable to locate the Join Game dialog dialog; does this person have Bob's Tall Tales?", serverName);
                return false;
            }

            Mouse.Click();
            await Task.Delay(2500); // Allow for servers to load
            if (!PrimaryMonitor.IsShowing(config.IsOnServerListingScreenPixel))
            {
                _logger.LogWarning("Attempted to join server {Server} but did not successfully reach the server listing screen.", serverName);
                return false;
            }

            Mouse.Click(config.ServerSearchbarPos.ToCoord());
            await Task.Delay(1000);
            Input.Send(serverName);
            await Task.Delay(2500);
            Mouse.Click(config.SelectServerPixel.Position.ToCoord());
            await Task.Delay(1000);
            if (!PrimaryMonitor.IsShowing(config.SelectServerPixel))
            {
                _logger.LogWarning("Attempted to join server {Server} but was unable to select it after searching for it on the server listing page.", serverName);
                OnServerMissing?.Invoke(this, new ServerMissingEventArgs(serverName));
                return false;
            }

            Mouse.Click(config.JoinServerBtnPos.ToCoord());
            // At this point we are joining the server
            return true;
        }

        public async Task<bool> JoinLastServer()
        {
            var config = await _configProvider.GetConfigAsync();
            if (!await IsHomeScreenShowing())
            {
                _logger.LogWarning("Attempted to join the last played session, but was not on the homescreen.");
                return false;
            }

            Mouse.Click(config.JoinLastSessionBtnPixel.Position.ToCoord());
            return true;
        }        
    }
}
