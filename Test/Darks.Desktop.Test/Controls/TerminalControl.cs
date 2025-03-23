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
    public partial class TerminalControl : UserControl
    {
        private readonly TerminalManager _terminalManager;

        public TerminalControl(TerminalManager terminalManager)
        {
            InitializeComponent();
            _terminalManager = terminalManager;
        }

        private async void OnSendBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _terminalManager.Write(terminalTxtBox.Text);
        }
    }
}
