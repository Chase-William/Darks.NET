using Darks.Core.Models.Account;
using Darks.Core.Models.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Data;

public class ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : DbContext(options), IApplicationDatabaseContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<MachineModel> Machines { get; set; }
}