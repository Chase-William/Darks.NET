using Darks.Dispatch.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Services.Dispatch;
internal class DispatchService : IDispatchJobs
{
    private readonly ILogger<DispatchService> _logger;
    private readonly IManageJobs _jobManager;
    private readonly ILaborPool _laborPool;

    public DispatchService(
        ILogger<DispatchService> logger,
        IManageJobs jobManager,
        ILaborPool laborPool)
    {
        _logger = logger;
        _jobManager = jobManager;
        _laborPool = laborPool;

        _jobManager.JobAvailable += (sender, args) =>
        { // Find a worker to perform this job if possible
            
        };
    }
}
