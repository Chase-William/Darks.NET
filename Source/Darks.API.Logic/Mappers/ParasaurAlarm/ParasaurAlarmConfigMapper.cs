using Darks.Core.Models.Inventory;
using Darks.Core.Models.ParasaurAlarm;
using Darks.Core.ViewModels.Inventory;
using Darks.Core.ViewModels.ParasaurAlarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Mappers.ParasaurAlarm
{
    public static class ParasaurAlarmConfigMapper
    {
        public static ParasaurAlarmConfigViewModel ToViewModel(this ParasaurAlarmConfigModel model)
        {
            return new ParasaurAlarmConfigViewModel(model);
        }
    }
}
