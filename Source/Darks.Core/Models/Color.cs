using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models;

[Owned]
public class Color
{
    public Color() { }

    public Color(int red, int green, int blue) 
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public bool Matches(Color color)
    {
        throw new NotImplementedException();
    }

    public bool Matches(System.Drawing.Color color)
        => Red == color.R && Green == color.G && Blue == color.B;
}

