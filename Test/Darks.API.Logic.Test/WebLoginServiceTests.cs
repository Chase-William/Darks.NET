using NSubstitute;

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Darks.API.Infrastructure.Data;

using Darks.Core.Models.Auth.Login;
using Darks.API.Infrastructure.Interfaces.Account;
using Darks.API.Logic.Interfaces.Auth.Login;
using Darks.Core.Models.Account;
using Darks.API.Logic.Services.Auth.Login;

namespace Darks.API.Logic.Test;

public class WebLoginServiceTest
{
    private readonly IUserRepository _userRepository;
    private readonly IWebLoginService _webLoginService;

    public WebLoginServiceTest()
    {        
        _userRepository = Substitute.For<IUserRepository>();
        _webLoginService = new WebLoginService(_userRepository);
    }
    
    [Theory]
    [InlineData("user", "pass")]
    public async void WebLoginIsWorkingCorrectly(string username, string password)
    {
        _userRepository.GetUserByUsernameAsync(username).Returns(new User
        {
            Username = username,
            Password = password
        });

        var result = await _webLoginService.LoginAsync(new WebLoginRequest
        {
            Username = username,
            Password = password
        });

        result.Should().Be(true);
    }
}
