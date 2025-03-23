﻿using Darks.Core.Common;
using Darks.Core.ViewModels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Logic.Services
{
    public interface IConfigService<TViewModel>
    {
        Task<Result<TViewModel>> GetViewModelByResolutionIdAsync(int rid);
    }
}
