using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Exceptions
{
    public class InvalidKeyException(string keyStr) : Exception
    {
        public string KeyString { get; init; } = keyStr;
    }
}
