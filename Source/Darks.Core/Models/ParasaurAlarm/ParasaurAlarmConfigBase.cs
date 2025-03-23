using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.ParasaurAlarm
{
    public class ParasaurAlarmConfigBase : Model
    {
        public Rect AlarmScreenshotRect { get; set; }
        public Color AlarmColor { get; set; }
    }
}
