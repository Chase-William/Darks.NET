using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Darks.Core.Models.Account;

namespace Darks.API.Infrastructure.Interfaces.Account
{
    public interface IMachineRepository
    {
         MachineModel GetMachineByHwid(string id);
    }
}
