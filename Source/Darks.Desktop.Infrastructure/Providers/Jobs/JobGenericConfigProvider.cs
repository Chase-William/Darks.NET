using Darks.Core.ViewModels.Jobs;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Jobs;
internal class JobGenericConfigProvider : IJobGenericConfigProvider
{
    public Task<JobGenericConfigViewModel> GetConfigAsync()
    {
        throw new NotImplementedException();
    }
}
