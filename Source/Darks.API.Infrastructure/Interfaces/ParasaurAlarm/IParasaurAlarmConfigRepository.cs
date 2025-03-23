using Darks.API.Infrastructure.Repositories;
using Darks.Core.Common;
using Darks.Core.Models.ParasaurAlarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Interfaces.ParasaurAlarm
{
    public interface IParasaurAlarmConfigRepository : IConfigRepository<ParasaurAlarmConfigModel>
    {
    }
}
