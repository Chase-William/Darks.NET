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
    public partial class TribeLogControl : UserControl
    {
        private readonly TribeLogCapturer _tribeLogCapturer;

        public TribeLogControl(TribeLogCapturer tribeLogCapturer)
        {
            InitializeComponent();
            _tribeLogCapturer = tribeLogCapturer;
        }

        private async void OnOpenTribeLogBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _tribeLogCapturer.OpenAsync();
        }

        private async void OnCloseTribeLogBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _tribeLogCapturer.CloseAsync();
        }

        private async void OnTakeScreenshotBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _tribeLogCapturer.GetTribeLogScreenshot();
        }
    }
}
