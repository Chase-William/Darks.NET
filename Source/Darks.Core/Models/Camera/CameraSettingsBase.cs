using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Camera;
public class CameraSettingsBase : Model
{
    public string Left { get; set; }
    public string Right { get; set; }
    public string Up { get; set; }
    public string Down { get; set; }
}
