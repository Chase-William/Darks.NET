using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models;

[Owned]
public class Rect
{
    public Rect() { }
    public Rect(int left, int top, int right, int bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }

    public int GetWidth() => Math.Abs(Right - Left);
    public int GetHeight() => Math.Abs(Bottom - Top);
}
