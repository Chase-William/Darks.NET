using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Jobs.Crate
{
    public class CrateJobBlueprint : JobBlueprint
    {        
        public Components.Crate[] Crates { get; set; }
    }
}
