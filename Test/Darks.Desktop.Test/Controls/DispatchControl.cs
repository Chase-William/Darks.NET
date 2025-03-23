using Darks.Core.Models.Jobs.BerryFerry;
using Darks.Core.Models.Jobs.Crate;
using Darks.Core.Models.Jobs.Oil;
using Darks.Core.Models.Jobs.Render;
using Darks.Desktop.Logic.Enums;
using Darks.Desktop.Logic.Factories;
using Darks.Desktop.Logic.Interfaces;
using Darks.Desktop.Test.Data;
using Darks.Dispatch.Factories;
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
    internal partial class DispatchControl : UserControl
    {
        private readonly IWorkerClientFactory _workerClientFactory;
        private readonly RecurringJobEmitter _recurringJobEmitter;
        private readonly SeedService _seedService;
        private IWorkerClient? _workerClient; 

        private readonly RenderJobBlueprint _renderJob;
        private readonly OilJobBlueprint _oilJob;
        private readonly BerryFerryJobBlueprint _berryJob;
        private readonly CrateJobBlueprint _crateJob;

        public DispatchControl(
            IWorkerClientFactory workerClientFactory,
            RecurringJobEmitter recurringJobEmitter,
            SeedService seedService)
        {
            InitializeComponent();
            _workerClientFactory = workerClientFactory;
            _recurringJobEmitter = recurringJobEmitter;
            _seedService = seedService;

            _renderJob = _seedService.GetRenderJob();
            _oilJob = _seedService.GetOilJob();
            _berryJob = _seedService.GetBerryFerryJob();
            _crateJob = _seedService.GetCrateJob();
        }

        private async void OnToggleWorkForceJoinedBtnClicked(object sender, EventArgs e)
        {
            if (_workerClient is null) return;
            if (_workerClient.HasJoinedWorkforce)
            {
                if (await _workerClient.LeaveWorkforce())
                    button1.Text = "Start Botting";
            }
            else
            {
                if (await _workerClient.JoinWorkforce())
                    button1.Text = "Stop Botting";
            }
        }

        private async void OnLocalDispatchRadioBtnValueChanged(object sender, EventArgs e)
        {
            // Leave the workforce if needed cause we are swapping from remote
            if (_workerClient is not null && (_workerClient?.HasJoinedWorkforce ?? false))
                if (await _workerClient.LeaveWorkforce())
                    button1.Text = "Start Botting";

            if (((RadioButton)sender).Checked)
                _workerClient = _workerClientFactory.CreateWorker(DispatchMode.Local);
        }

        private void OnRemoteDispatchRadioBtnValueChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                _workerClient = _workerClientFactory.CreateWorker(DispatchMode.Remote);
        }

        private void OnEnableRenderJob_CheckedChanged(object sender, EventArgs e)
        {
            if (enableRenderJob.Checked)
            {
                _recurringJobEmitter.Register(
                       _renderJob,
                       5 * 60 * 1000, //2mins for testing
                       queueImmediatelyRender.Checked);
            }
            else
                _recurringJobEmitter.Unregister(_renderJob);
        }

        private void OnEnableOilJob_CheckedChanged(object sender, EventArgs e)
        {
            if (enableOilJob.Checked)
            {
                _recurringJobEmitter.Register(
                       _oilJob,
                       240 * 60 * 1000, // 4hrs
                       queueImmediatelyOil.Checked);
            }
            else
                _recurringJobEmitter.Unregister(_oilJob);
        }

        private void OnEnableBerryFerry_CheckedChanged(object sender, EventArgs e)
        {
            if (enableBerryFerry.Checked)
            {
                _recurringJobEmitter.Register(
                       _berryJob,
                       30 * 60 * 1000, // 30mins
                       queueImmediatelyBerryFerry.Checked);
            }
            else
                _recurringJobEmitter.Unregister(_berryJob);
        }

        private void OnEnableCratesJob_CheckedChanged(object sender, EventArgs e)
        {
            if (enableCratesJob.Checked)
            {
                _recurringJobEmitter.Register(
                       _crateJob,
                       50 * 60 * 1000, // 50mins
                       queueImmediatelyCrates.Checked);
            }
            else
                _recurringJobEmitter.Unregister(_crateJob);
        }
    }
}
