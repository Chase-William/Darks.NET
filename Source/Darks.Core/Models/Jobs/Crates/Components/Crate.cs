using Darks.Core.Models.Jobs.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Jobs.Crate.Components;

[Owned]
public class Crate
{
    public bool Enabled { get; set; }
    public bool IsDoubleHarvestable { get; set; }
    public bool WaitUntilDeath { get; set; }
    public int LoadDelay { get; set; }
    public string BedName { get; set; } = string.Empty;
    public HowToGetInventoryInfo GetCrateInventoryInfo { get; set; }
    public HowToGetInventoryInfo GetDepositInventoryInfo { get; set; }
}
