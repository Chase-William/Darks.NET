using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.TribeLog
{
    public class TribeLogScreenConfigBase : Model
    {
        public Pixel IsTribeLogOpenPixel { get; set; }
        public Rect TribeLogScreenshotRect { get; set; }
        public Point ToggleOnlineMembersBtnPos { get; set; }
    }
}
