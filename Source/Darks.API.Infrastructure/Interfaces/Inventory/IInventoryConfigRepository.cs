﻿using Darks.API.Infrastructure.Repositories;
using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Interfaces.Inventory
{
    public interface IInventoryConfigRepository : IConfigRepository<InventoryScreenConfigModel>
    {
    }
}
