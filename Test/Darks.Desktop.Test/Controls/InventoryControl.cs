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

using Darks.Core.Enums;

namespace Darks.Desktop.Test.Controls
{
    public partial class InventoryControl : UserControl
    {
        private readonly InventoryManager _inventoryManager;

        public InventoryControl(InventoryManager inventoryManager)
        {
            InitializeComponent();
            _inventoryManager = inventoryManager;
        }

        private async void OnOpenInventoryBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _inventoryManager.OpenAsync(Inventory.Self);
        }

        private async void OnCloseInventoryBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _inventoryManager.CloseAsync(Inventory.Self);
        }

        private async void OnGiveAllBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _inventoryManager.TransferAllAsync(Inventory.Other);
        }

        private async void OnTakeAllBtnClicked(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await _inventoryManager.TransferAllAsync(Inventory.Self);
        }
    }
}
