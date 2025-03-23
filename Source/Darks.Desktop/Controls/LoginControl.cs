using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Darks.Desktop.Logic.Services.Auth.Login;
using Darks.Core.Models.Auth.Login;
using Darks.Desktop.Logic.Services.Native;

namespace Darks.Desktop.Controls
{
    public partial class LoginControl : UserControl
    {
        private readonly LoginManager _loginManager;
        private readonly Action<DesktopLoginResponse> _onLoggedIn;

        public LoginControl(LoginManager loginService, Action<DesktopLoginResponse> onLoggedIn)
        {
            _loginManager = loginService;
            _onLoggedIn = onLoggedIn;
            InitializeComponent();
        }        

        private async void OnLoginBtn_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.Enabled = false;

            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;

            // Validate username/password
            
            var loginResponse = await _loginManager.LoginAsync(username, password);

            // Check if null
            if (loginResponse.HasError())
            {
                
            }
            else
            {
                _onLoggedIn?.Invoke(loginResponse.Data!);
            }
            btn.Enabled = true;
        }
    }
}
