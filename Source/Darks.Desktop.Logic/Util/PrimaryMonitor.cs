using Darks.Core.Models;
using Darks.Core.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;
using Monitor = WinUtilities.Monitor;

namespace Darks.Desktop.Logic.Util
{
    public static class PrimaryMonitor
    {
        public static bool IsShowing(Pixel px)
        {
            var img = (Bitmap)Monitor.GetImage(new Area(px.Position.X, px.Position.Y, 1, 1));
            return px.Color.Matches(img.GetPixel(0, 0));
        }

        public static (int width, int height) GetResolution()
        {
            var area = Window.Active.Monitor.Area;
            return new((int)area.W, (int)area.H);
        }
    }
}
