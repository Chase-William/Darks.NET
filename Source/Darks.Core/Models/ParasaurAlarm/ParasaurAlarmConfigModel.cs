using Darks.Core.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.ParasaurAlarm
{
    public class ParasaurAlarmConfigModel : ParasaurAlarmConfigBase
    {
        public ResolutionModel Resolution { get; set; }        
    }
}
