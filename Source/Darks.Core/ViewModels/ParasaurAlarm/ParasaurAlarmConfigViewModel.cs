using Darks.Core.Models.ParasaurAlarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.ViewModels.ParasaurAlarm
{
    public class ParasaurAlarmConfigViewModel : ParasaurAlarmConfigBase
    {
        public ParasaurAlarmConfigViewModel() { }
        public ParasaurAlarmConfigViewModel(ParasaurAlarmConfigBase modelBase)
        {
            Id = modelBase.Id;
            AlarmScreenshotRect = modelBase.AlarmScreenshotRect;
            AlarmColor = modelBase.AlarmColor;
        }
    }
}
