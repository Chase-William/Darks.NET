using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Exceptions
{
    internal class GameRestartException(string message) : Exception(message)
    {
    }
}
