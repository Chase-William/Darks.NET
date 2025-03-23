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
    public partial class IdleControl : UserControl
    {
        private readonly IdleStateManager _idleStateManager;

        public IdleControl(IdleStateManager idleStateManager)
        {
            InitializeComponent();
            _idleStateManager = idleStateManager;
        }

        private async void OnEnterIdleStateBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _idleStateManager.EnterIdleStateAsync(new CancellationToken());
        }

        private async void OnLeaveIdleStateBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _idleStateManager.LeaveIdleStateAsync();
        }
    }
}
