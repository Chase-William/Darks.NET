using Darks.Core.Common;
using Darks.Core.Models.ParasaurAlarm;
using Darks.Core.ViewModels.ParasaurAlarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Interfaces
{
    public interface IParasaurAlarmConfigProvider
    {
        Task<ParasaurAlarmConfigViewModel> GetConfigAsync();
    }
}
