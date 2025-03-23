using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Configuration
{
    public interface IReadonlyDispatcherConfiguration
    {
        public string ConnectionUrl { get; }

        #region Server To Client
        public string RequestWorkerStartJob { get; }
        public string RequestWorkerCancelJob { get; }
        #endregion

        #region Client To Server
        public string NotifyServerJobStartedMessageName { get; }
        public string NotifyServerJobCompletedMessageName { get; }
        public string NotifyServerJobAbandonedMessageName { get; }
        public string NotifyServerJobRecoveryMessageName { get; }
        #endregion
    }
}
