using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darks.Desktop.Controls
{
    public partial class ToggleControl : UserControl
    {
        private readonly Action<bool> _onToggled;

        private bool toggleState;

        public ToggleControl(Action<bool> onToggled)
        {
            _onToggled = onToggled;
            InitializeComponent();
        }

        private void OnToggleBtn_Clicked(object sender, EventArgs e)
            => _onToggled?.Invoke(toggleState = !toggleState);
    }
}
