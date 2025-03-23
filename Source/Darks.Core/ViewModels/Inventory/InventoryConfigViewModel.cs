using Darks.Core.Models;
using Darks.Core.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.ViewModels.Inventory
{
    public class InventoryConfigViewModel : InventoryScreenConfigBase
    {
        public InventoryConfigViewModel() { }
        public InventoryConfigViewModel(InventoryScreenConfigBase modelBase)
        {
            Id = modelBase.Id;
            IsOtherInventroyOpenPixel = modelBase.IsOtherInventroyOpenPixel;
            IsSelfInventroyOpenPixel = modelBase.IsSelfInventroyOpenPixel;
            OtherFirstSlotPos = modelBase.OtherFirstSlotPos;
            SelfFirstSlotPos= modelBase.SelfFirstSlotPos;
            OtherToSelfTransferBtnPos = modelBase.OtherToSelfTransferBtnPos;
            SelfToOtherTransferBtnPos = modelBase.SelfToOtherTransferBtnPos;
        }
    }
}
