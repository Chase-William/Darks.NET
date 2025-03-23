using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Args
{
    public class ScreenshotCapturedArgs(
        Bitmap screenshot, 
        string extraInfo = "") : BasicUpdateArgs(extraInfo)
    {
        public Bitmap Screenshot { get; init; } = screenshot;        
    }
}
