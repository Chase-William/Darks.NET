using Darks.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services.Dispatch;

public class JobExecutionContext
{
    public ExecutableJob Job { get; init; }
    public Action CompletionHandler { get; init; }
    internal JobExecutionContext(ExecutableJob job, Action completionHandler)
    {
        Job = job;
        CompletionHandler = completionHandler;
    }
}
