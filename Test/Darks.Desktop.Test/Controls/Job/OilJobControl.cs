using Darks.Core.Models.Jobs.BerryFerry;
using Darks.Core.Models.Jobs.Oil;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Test.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darks.Desktop.Test.Controls.Job;
internal partial class OilJobControl : UserControl
{
    private readonly SeedService _seedService;

    private CancellationTokenSource? tokenSource;

    public OilJobControl(SeedService seedService)
    {
        InitializeComponent();
        _seedService = seedService;
    }

    private async void OnRunBtnClicked(object sender, EventArgs e)
    {
        try
        {
            if (tokenSource is not null)
            {
                runJobBtn.Enabled = false;
                await tokenSource.CancelAsync();
                runJobBtn.Invoke(() => runJobBtn.Enabled = true);
            }
            else
            {
                runJobBtn.Text = "Cancel";
                tokenSource = new CancellationTokenSource();
                var jobManager = _seedService.GetOilJobManagerTestData();
                await Task.Delay(5000, tokenSource.Token);
                await jobManager.Run(tokenSource.Token);
            }
        }
        catch (OperationCanceledException ex)
        {
            MessageBox.Show("Job Cancelled");
        }
        finally
        {
            runJobBtn.Invoke(() => runJobBtn.Text = "Run");
        }
    }
}
