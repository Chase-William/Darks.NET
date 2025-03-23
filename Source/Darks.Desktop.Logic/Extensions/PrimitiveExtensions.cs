using Darks.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Extensions
{
    public static class PrimitiveExtensions
    {
        public static Coord ToCoord(this Point point)
            => new(point.X, point.Y);
        public static Area ToArea(this Rect rect)
            => new(rect.Left, rect.Top, rect.GetWidth(), rect.GetHeight());
    }
}
