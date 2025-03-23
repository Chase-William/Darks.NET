using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Args;

public class MissingBedEventArgs(string bedName) : EventArgs
{
    public string BedName { get; init; } = bedName;
}
