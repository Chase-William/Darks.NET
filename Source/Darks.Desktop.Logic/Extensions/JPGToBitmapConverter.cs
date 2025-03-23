using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Converters
{
    internal static class JPGToBitmapConverter
    {
        public static MemoryStream CopyToJPG(this Bitmap bmp)
        {
            using MemoryStream memStream = new();

#pragma warning disable CA1416 // Validate platform compatibility
            bmp.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
#pragma warning restore CA1416 // Validate platform compatibility

            memStream.Position = 0;

            return new MemoryStream(memStream.ToArray());
        }
    }
}
