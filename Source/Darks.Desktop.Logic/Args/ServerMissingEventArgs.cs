using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Args
{
    public class ServerMissingEventArgs(string extraInfo = "") : BasicUpdateArgs(extraInfo)
    {
    }
}
