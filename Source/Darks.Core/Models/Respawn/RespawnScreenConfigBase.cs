using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Respawn
{
    public class RespawnScreenConfigBase : Model
    {
        public Point SpawnBtnPos { get; set; }
        public Point DeathScreenSearchbarPos { get; set; }
        public Point FastTravelScreenSearchbarPos { get; set; }
        public Pixel SelectBedPixel { get; set; }
        public Pixel IsFastTravelScreenOpenPixel { get; set; }
        public Pixel IsDeathScreenOpenPixel { get; set; }
    }
}
