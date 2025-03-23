using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Process
{
    public class ProcessConfigBase : Model
    {
        public string UrlShortcutFileContent { get; set; }
        public string UrlShortcutFileName { get; set; }
        public string ArkProcessName { get; set; }
    }
}
