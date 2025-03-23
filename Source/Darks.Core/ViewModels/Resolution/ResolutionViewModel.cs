using Darks.Core.Models.Resolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.ViewModels.Resolution
{
    public class ResolutionViewModel : ResolutionBase
    {
        public ResolutionViewModel(ResolutionModel model)
        {
            base.Id = model.Id;
            base.Width = model.Width;
            base.Height = model.Height;
        }
    }
}
