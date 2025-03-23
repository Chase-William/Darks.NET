using Darks.Core.Models.Jobs;
using Darks.Desktop.Logic.Args.Jobs;
using Darks.Desktop.Logic.Services.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Interfaces
{
    public interface IWorkerService
    {
        JobManager? CurrentJobManager { get; }

        event EventHandler<JobChangedEventArgs> OnJobManagerChanged;
    }
}
