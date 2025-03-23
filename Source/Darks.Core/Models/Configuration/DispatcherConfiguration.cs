using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Configuration
{
    public class DispatcherConfiguration : Model, IReadonlyDispatcherConfiguration
    {
        public string ConnectionUrl { get; set; }

        public string RequestWorkerStartJob { get; set; }

        public string RequestWorkerCancelJob { get; set; }

        public string NotifyServerJobStartedMessageName { get; set; }

        public string NotifyServerJobCompletedMessageName { get; set; }

        public string NotifyServerJobAbandonedMessageName { get; set; }

        public string NotifyServerJobRecoveryMessageName { get; set; }
    }
}
