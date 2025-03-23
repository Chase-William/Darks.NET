using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Auth.Login
{
    public class DesktopLoginRequest : WebLoginRequest
    {
        public string Hwid { get; set; }
        public int DisplayWidth { get; set; }
        public int DisplayHeight { get; set; }
    }
}
