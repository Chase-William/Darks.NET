using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Jobs.Sap
{
    public class SapJobBlueprint : JobBlueprint
    {        
        public string[] BedNames { get; set; }
    }
}
