using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models;

[Owned]
public class Pixel
{
    public Pixel() { }

    public Pixel(int x, int y, Color color)
    {
        Position = new Point(x, y);
        Color = color;
    }

    public Point Position { get; set; }
    public Color Color { get; set; }
}
