using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.Common;
using System.Net.Http.Json;

using Darks.Desktop.Controls;
using Darks.Desktop.Logic.Services.Auth.Login;
using Darks.Core.Models.Auth.Login;
using Darks.Desktop.Logic.Services;

namespace Darks.Desktop
{
    public partial class MainWindow : Form
    {
        //static string JwtToken = string.Empty;
        //HubConnection? _connection;

        public MainWindow(IServiceProvider serviceProvider, Action<DesktopLoginResponse> onLoggedIn)
        {
            InitializeComponent();
            Controls.Add(new LoginControl(serviceProvider.GetRequiredService<LoginManager>(), onLoggedIn));
            //Controls.Add(new LoginControl(loginService, onLoggedIn));
        }

        //private async void OnMessageBtnClicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var message = msgTxt.Text;
        //        sent_msgs.Items.Add($"{_connection.ConnectionId}: {message}");
        //        await _connection.SendAsync("SendUpdate", "group-1", message);
        //        msgTxt.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private async void OnToggleConnectionBtnClicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _connection = new HubConnectionBuilder()
        //            .WithUrl("https://localhost:7131/update-hub", options =>
        //            {
        //                options.AccessTokenProvider = () => Task.FromResult(JwtToken);
        //            })
        //        .Build();

        //        _connection.On<string>("ReceiveUpdate", (message) =>
        //        {
        //            receive_msgs.Invoke(() =>
        //            {
        //                receive_msgs.Items.Add($"{message}");
        //            });
        //        });

        //        await _connection.StartAsync();
        //        await _connection.SendAsync("JoinGroup", "group-1");

        //        conn_status_lbl.Invoke(delegate
        //        {
        //            conn_status_lbl.Text = "(Connected $ Joined Group)";
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private async void OnLoginBtnClicked(object sender, EventArgs e)
        //{
        //    var username = usernameTxtBox.Text;
        //    var password = passwordTxtBox.Text;

        //    try
        //    {
        //        using HttpClient client = new();

        //        var res = await client.PostAsJsonAsync("https://localhost:7131/api/auth/login", new LoginModel
        //        {
        //            Username = username,
        //            Password = password
        //        });

        //        if (res.IsSuccessStatusCode)
        //        {
        //            var loginRes = await res.Content.ReadFromJsonAsync<LoginResponse>();
        //            if (loginRes is null)
        //            {
        //                return;
        //            }
        //            JwtToken = loginRes.AuthToken;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine();
        //    }
        //}
    }
}
