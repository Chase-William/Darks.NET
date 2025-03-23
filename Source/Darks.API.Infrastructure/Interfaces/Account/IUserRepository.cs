using Darks.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.API.Infrastructure.Interfaces.Account
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
