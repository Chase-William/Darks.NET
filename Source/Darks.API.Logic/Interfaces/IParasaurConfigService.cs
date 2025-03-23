using Darks.API.Logic.Services;
using Darks.Core.ViewModels.ParasaurAlarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Interfaces
{
    public interface IParasaurConfigService : IConfigService<ParasaurAlarmConfigViewModel>
    {
    }
}
