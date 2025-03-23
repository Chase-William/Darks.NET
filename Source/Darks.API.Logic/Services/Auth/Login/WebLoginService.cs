using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darks.API.Infrastructure.Interfaces.Account;
using Darks.API.Logic.Interfaces.Auth.Login;
using Darks.Core.Models.Auth.Login;

namespace Darks.API.Logic.Services.Auth.Login
{
    internal class WebLoginService(IUserRepository userRepository) : IWebLoginService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<bool> LoginAsync(WebLoginRequest login)
        {
            var user = await _userRepository.GetUserByUsernameAsync(login.Username);

            if (user is null)
                return false;

            if (login.Username == user.Username && login.Password == user.Password)
                return true;
            return false;
        }        
    }
}
