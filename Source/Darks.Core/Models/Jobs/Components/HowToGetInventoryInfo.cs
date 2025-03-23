using Darks.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Jobs.Components;

[Owned]
public class HowToGetInventoryInfo
{
    public PivotDirection Direction { get; set; }
    public int InitialPivotDuration { get; set; }
    public int Increment { get; set; }
    public int Attempts { get; set; }
}