using Darks.Core.Models.Jobs;
using Darks.Desktop.Logic.Services.Jobs;
using Darks.Dispatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Args.Jobs
{
    public class JobChangedEventArgs(JobManager? previous, JobManager? current) : EventArgs
    {
        public JobManager? Previous { get; set; } = previous;
        public JobManager? Current { get; set; } = current;
    }
}
