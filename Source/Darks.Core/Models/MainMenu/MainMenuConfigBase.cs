using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.MainMenu
{
    public class MainMenuConfigBase : Model
    {
        public Pixel JoinLastSessionBtnPixel { get; set; }
        public Point HomePageJoinBtnPos { get; set; }
        public Pixel JoinGameDialogPixel { get; set; }
        public Pixel IsOnServerListingScreenPixel { get; set; }
        public Point ServerSearchbarPos { get; set; }
        public Point JoinServerBtnPos { get; set; }
        public Pixel SelectServerPixel { get; set; }
    }
}
