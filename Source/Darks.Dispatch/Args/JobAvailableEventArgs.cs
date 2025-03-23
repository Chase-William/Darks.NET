using Darks.Desktop.Logic.Services.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Dispatch.Args;
public class JobAvailableEventArgs(JobExecutionContext jobCtx) : EventArgs
{
    public JobExecutionContext Context { get; init; } = jobCtx;
}
