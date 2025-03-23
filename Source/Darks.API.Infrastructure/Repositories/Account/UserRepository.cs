using Darks.API.Infrastructure.Data;
using Darks.API.Infrastructure.Interfaces.Account;
using Darks.Core.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Repositories.Account
{
    internal class UserRepository(ILogger<UserRepository> logger, IApplicationDatabaseContext appDbCtx) : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger = logger;
        private readonly IApplicationDatabaseContext _appDbCtx = appDbCtx;

        public async Task<User?> GetUserByUsernameAsync(string username)
            => await _appDbCtx.Users.SingleOrDefaultAsync(user => user.Username == username);        
    }
}
