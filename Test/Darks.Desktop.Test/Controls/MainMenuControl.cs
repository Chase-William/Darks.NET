using Darks.Desktop.Logic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darks.Desktop.Test.Controls
{
    public partial class MainMenuControl : UserControl
    {
        private readonly MainMenuManager _mainMenuManager;

        public MainMenuControl(MainMenuManager mainMenuManager)
        {
            InitializeComponent();
            _mainMenuManager = mainMenuManager;
        }

        private async void OnJoinServerBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _mainMenuManager.JoinServer(serverTxtBox.Text);
        }

        private async void OnJoinLastSessionBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _mainMenuManager.JoinLastServer();
        }

        private async void OnExitToMainMenu(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _mainMenuManager.ExitToMainMenu();
        }
    }
}
