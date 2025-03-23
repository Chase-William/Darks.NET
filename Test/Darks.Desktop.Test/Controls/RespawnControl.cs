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
    public partial class RespawnControl : UserControl
    {
        private readonly RespawnManager _respawnManager;

        public RespawnControl(RespawnManager respawnManager)
        {
            InitializeComponent();
            _respawnManager = respawnManager;
        }

        private async void OnFastTravelBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _respawnManager.FastTravelAsync(bedNameTxtBox.Text);
        }

        private async void OnRespawnBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _respawnManager.RespawnAsync(bedNameTxtBox.Text);
        }
    }
}
