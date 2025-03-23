using Darks.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Dispatch.Args;

public class ExecutableJobEventArgs(ExecutableJob job) : EventArgs
{
    public ExecutableJob Job { get; set; } = job;
}

