using Darks.Core.Models.Jobs;
using Darks.Desktop.Logic.Args.Jobs;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Dispatch;
using Darks.Dispatch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Interfaces;
internal interface IWorkerClient : IWorker
{
    bool HasJoinedWorkforce { get; }
    Task<bool> JoinWorkforce();
    Task<bool> LeaveWorkforce();

    JobManager? CurrentJob { get; }

    event EventHandler<JobChangedEventArgs>? JobChanged;
}
