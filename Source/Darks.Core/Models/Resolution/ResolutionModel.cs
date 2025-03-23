using Darks.Core.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Resolution;

public class ResolutionModel : ResolutionBase
{    
    // public int? InventoryScreenConfigId { get; set; }
    public InventoryScreenConfigModel? InventoryScreenConfig { get; set; }

}
