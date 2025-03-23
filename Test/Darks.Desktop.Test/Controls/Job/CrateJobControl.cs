using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Darks.Core.Models.Jobs.Oil;
using Darks.Desktop.Logic.Factories;
using Darks.Core.Models.Jobs.Crate;
using Darks.Core.Models.Jobs.Crate.Components;
using Darks.Core.Models.Jobs.Components;
using Darks.Desktop.Test.Data;

namespace Darks.Desktop.Test.Controls.Job;

internal partial class CrateJobControl : UserControl
{
    private readonly SeedService _seedService;
    private CancellationTokenSource? tokenSource;
        
    public CrateJobControl(SeedService seedService)
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

                var jobManager = _seedService.GetCrateJobManagerTestData();

                await Task.Delay(5000, tokenSource.Token);
                await jobManager.Run(tokenSource.Token);
            }
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show("Job Cancelled");
        }
        finally
        {
            runJobBtn.Invoke(() => runJobBtn.Text = "Run");
        }
    }
}
