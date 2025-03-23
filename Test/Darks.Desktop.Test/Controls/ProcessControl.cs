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
    public partial class ProcessControl : UserControl
    {
        private readonly ProcessManager _processManager;

        public ProcessControl(ProcessManager processManager)
        {
            InitializeComponent();
            _processManager = processManager;
        }

        private async void OnLaunchArkBtnClicked(object sender, EventArgs e)
        {
            await _processManager.LaunchAsync();
        }

        private async void OnExitArkBtnClicked(object sender, EventArgs e)
        {
            await _processManager.ExitAsync();
        }

        private async void OnCheckIfArkIsRunningBtnClicked(object sender, EventArgs e)
        {
            isArkRunningLbl.Text = (await _processManager.IsRunningAsync()).ToString();
        }
    }
}
