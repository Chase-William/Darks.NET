using Darks.Desktop.Logic.Services.Dispatch;
using Darks.Dispatch.Args;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Dispatch.Interfaces;

public interface IManageJobs
{
    ImmutableDictionary<Guid, JobExecutionContext> AvailableJobs { get; }
    event EventHandler<JobAvailableEventArgs>? JobAvailable;
    bool TryTake(Guid uuid, out JobExecutionContext? jobCtx);
}
