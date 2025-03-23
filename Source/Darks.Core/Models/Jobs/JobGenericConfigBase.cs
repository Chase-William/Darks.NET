using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Jobs;
public class JobGenericConfigBase : Model
{
    public Rect ItemsTransferredScreenshotRect { get; set; }
    public Rect StructureInfoScreenshotRect { get; set; }
}
