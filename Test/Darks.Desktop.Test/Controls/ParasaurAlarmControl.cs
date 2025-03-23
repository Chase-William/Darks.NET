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
    public partial class ParasaurAlarmControl : UserControl
    {
        private readonly ParasaurAlarmDetector _parasaurAlarmDetector;

        public ParasaurAlarmControl(ParasaurAlarmDetector parasaurAlarmDetector)
        {
            InitializeComponent();
            _parasaurAlarmDetector = parasaurAlarmDetector;
        }

        private async void OnTakeScreenshotBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            var img = await _parasaurAlarmDetector.GetAlarmScreenshotAsync();
            alarmImgBox.Image = img;
        }

        private async void OnCheckIfDetectingBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            var result = await _parasaurAlarmDetector.IsAlarmingAsync();
            detectionStateLbl.Text = result.ToString();
        }
    }
}
