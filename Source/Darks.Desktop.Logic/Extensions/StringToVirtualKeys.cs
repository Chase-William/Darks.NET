using Darks.Desktop.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Extensions
{
    internal static class StringToVirtualKeys
    {
        public static Key ToKey(this string keyString)
        {
            if (!Enum.TryParse(keyString, out Key key))                           
                throw new InvalidKeyException(keyString);
            return key;
        }
    }
}
