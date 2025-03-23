using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Inventory
{
    public class InventoryScreenConfigBase : Model
    {
        public Pixel IsSelfInventroyOpenPixel { get; set; }
        public Pixel IsOtherInventroyOpenPixel { get; set; }
        public Point SelfToOtherTransferBtnPos { get; set; }
        public Point OtherToSelfTransferBtnPos { get; set; }
        public Point SelfFirstSlotPos { get; set; }
        public Point OtherFirstSlotPos { get; set; }
    }
}
