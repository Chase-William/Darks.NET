using Darks.Core.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Data
{
    internal interface IApplicationDatabaseContext : IDisposable
    {
        DbSet<User> Users { get; }
        DbSet<MachineModel> Machines { get; }
    }
}
