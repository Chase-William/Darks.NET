using Darks.Core.Models.Jobs.Render;
using Darks.Dispatch;
using Darks.Dispatch.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Args.Jobs.Render
{
    internal class BedRenderedEventArgs(
        ExecutableJob job,
        string bedName) : ExecutableJobEventArgs(job)
    {
        public string BedName { get; set; } = bedName;
    }
}
