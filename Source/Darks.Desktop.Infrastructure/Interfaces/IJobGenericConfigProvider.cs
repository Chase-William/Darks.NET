using Darks.Core.ViewModels.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface IJobGenericConfigProvider
    {
        Task<JobGenericConfigViewModel> GetConfigAsync();
    }
}
