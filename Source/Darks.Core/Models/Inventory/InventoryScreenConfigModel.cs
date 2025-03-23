using Darks.Core.Models.Resolution;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Inventory
{
    public class InventoryScreenConfigModel : InventoryScreenConfigBase
    {
        public InventoryScreenConfigModel() { }

        public ResolutionModel Resolution { get; set; }              
    }
}
