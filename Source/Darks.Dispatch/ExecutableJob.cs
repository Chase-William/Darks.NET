using Darks.Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Dispatch;
public class ExecutableJob
{
    public Guid UUID { get; init; } = Guid.NewGuid();
    public JobBlueprint Blueprint { get; init; }
    internal ExecutableJob(JobBlueprint bp)
        => Blueprint = bp;
}
