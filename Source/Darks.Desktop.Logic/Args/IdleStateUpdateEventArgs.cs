using Darks.Desktop.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Args
{
    public class IdleStateUpdateEventArgs(IdleState state) : EventArgs
    {
        public IdleState State { get; set; } = state;
    }
}
