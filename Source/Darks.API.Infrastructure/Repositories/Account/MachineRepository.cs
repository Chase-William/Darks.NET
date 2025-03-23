using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.API.Infrastructure.Interfaces.Account;
using Darks.Core.Models.Account;

namespace Darks.API.Infrastructure.Repositories.Account
{
    internal class MachineRepository : IMachineRepository
    {
        public MachineModel GetMachineByHwid(string id)
        {
            throw new NotImplementedException();
        }
    }
}
