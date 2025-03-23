using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories
{
    public interface IConfigRepository<TModel>
    {
        Task<Result<TModel>> GetConfigByResolutionIdAsync(int rid);
    }
}
