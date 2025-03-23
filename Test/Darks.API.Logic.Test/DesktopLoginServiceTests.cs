using Darks.API.Infrastructure.Interfaces;
using Darks.API.Infrastructure.Interfaces.Account;
using Darks.API.Logic.Interfaces.Auth;
using Darks.API.Logic.Interfaces.Auth.Login;
using Darks.API.Logic.Services.Auth.Login;
using Darks.Core.Models.Account;
using Darks.Core.Models.Auth.Login;
using Microsoft.EntityFrameworkCore;

using NSubstitute;

using System.Xml;
using Darks.API.Infrastructure.Data;
using Microsoft.Extensions.Options;
using FluentAssertions;
using Darks.API.Infrastructure.Repositories.Account;
using Darks.API.Logic.Services.Auth;
using Microsoft.Extensions.DependencyInjection;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Darks.API.Infrastructure.Repositories.Resolution;
using Darks.Core.Models.Resolution;

namespace Darks.API.Logic.Test
{
    public class DesktopLoginServiceTests
    {
        readonly ServiceProvider _provider;

        public DesktopLoginServiceTests()
        {
            var services = new ServiceCollection();

            services.AddSingleton(Substitute.For<ILogger<UserRepository>>());
            services.AddSingleton(Substitute.For<ILogger<ResolutionRepository>>());
            services.AddSingleton(Substitute.For<ILogger<DesktopLoginService>>());

            var tokenProvider = Substitute.For<IDesktopAuthTokenProvider>();
            tokenProvider.GenerateDesktopClientJWT(string.Empty, null, null).Returns(string.Empty);
            services.AddSingleton(tokenProvider);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IResolutionRepository, ResolutionRepository>();
            services.AddScoped<IDesktopLoginService, DesktopLoginService>();

            services.AddDbContext<IApplicationDatabaseContext, ApplicationDatabaseContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());                
            });

            services.AddDbContext<IConfigDatabaseContext, ConfigDatabaseContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
            });

            _provider = services.BuildServiceProvider();
        }

        [Theory]
        [InlineData("user", "pass", "123-321", 2560, 1440)]
        public async void DesktopLoginIsWorkingCorrectly(
            string username,
            string password,
            string hwid,
            int width,
            int height)
        {
            { // config data
                var context = _provider.GetService<ConfigDatabaseContext>();               
                context.Should().NotBeNull();
                context!.Resolutions.Add(new ResolutionModel
                {
                    Width = 2560,
                    Height = 1440
                });
                context.SaveChanges();
            }

            { // application data
                var context = _provider.GetService<ApplicationDatabaseContext>();
                context.Should().NotBeNull();
                context!.Users.Add(new User {
                    Username = username,
                    Password = password,
                    Machines =
                    [
                        new MachineModel
                        {
                            Hwid = hwid,
                            DisplayName = string.Empty,
                            DiscordBotToken = string.Empty
                        }
                    ]
                });                
                context.SaveChanges();
            }

            var authProvider = _provider.GetService<IDesktopLoginService>();
            authProvider.Should().NotBeNull();

            var result = await authProvider!.LoginAsync(new DesktopLoginRequest
            {
                Username = username,
                Password = password,
                DisplayWidth = width,
                DisplayHeight = height,
                Hwid = hwid
            });

            result.HasError().Should().Be(false);            
        }

        [Theory]
        [InlineData("user", "pass", "123-848", 2560, 1440)]
        public async void DesktopLoginFailsAsHwidIsIncorrect(
            string username,
            string password,
            string hwid,
            int width,
            int height)
        {
            { // config data
                var context = _provider.GetService<ConfigDatabaseContext>();
                context.Should().NotBeNull();
                context!.Resolutions.Add(new ResolutionModel
                {
                    Width = 2560,
                    Height = 1440
                });
                context.SaveChanges();
            }

            { // application data
                var context = _provider.GetService<ApplicationDatabaseContext>();
                context.Should().NotBeNull();
                context!.Users.Add(new User
                {
                    Username = username,
                    Password = password,
                    Machines =
                    [
                        new MachineModel
                        {
                            Hwid = string.Empty, // <- should cause error
                            DisplayName = string.Empty,
                            DiscordBotToken = string.Empty
                        }
                    ]
                });
                context.SaveChanges();
            }

            var authProvider = _provider.GetService<IDesktopLoginService>();
            authProvider.Should().NotBeNull();

            var result = await authProvider!.LoginAsync(new DesktopLoginRequest
            {
                Username = username,
                Password = password,
                DisplayWidth = width,
                DisplayHeight = height,
                Hwid = hwid
            });

            result.HasError().Should().Be(true);
        }

        [Theory]
        [InlineData("user", "pass", "123-848", 2560, 1440)]
        public async void DesktopLoginFailsAsPasswordIsIncorrect(
            string username,
            string password,
            string hwid,
            int width,
            int height)
        {
            { // config data
                var context = _provider.GetService<ConfigDatabaseContext>();
                context.Should().NotBeNull();
                context!.Resolutions.Add(new ResolutionModel
                {
                    Width = 2560,
                    Height = 1440
                });
                context.SaveChanges();
            }

            { // application data
                var context = _provider.GetService<ApplicationDatabaseContext>();
                context.Should().NotBeNull();
                context!.Users.Add(new User
                {
                    Username = username,
                    Password = string.Empty, // <- should cause error
                    Machines =
                    [
                        new MachineModel
                        {
                            Hwid = hwid,
                            DisplayName = string.Empty,
                            DiscordBotToken = string.Empty
                        }
                    ]
                });
                context.SaveChanges();
            }

            var authProvider = _provider.GetService<IDesktopLoginService>();
            authProvider.Should().NotBeNull();

            var result = await authProvider!.LoginAsync(new DesktopLoginRequest
            {
                Username = username,
                Password = password,
                DisplayWidth = width,
                DisplayHeight = height,
                Hwid = hwid
            });

            result.HasError().Should().Be(true);
        }

        [Theory]
        [InlineData("user", "pass", "123-848", 2560, 1440)]
        public async void DesktopLoginFailsAsUnableToFindAccountWithUsername(
            string username,
            string password,
            string hwid,
            int width,
            int height)
        {
            { // config data
                var context = _provider.GetService<ConfigDatabaseContext>();
                context.Should().NotBeNull();
                context!.Resolutions.Add(new ResolutionModel
                {
                    Width = 2560,
                    Height = 1440
                });
                context.SaveChanges();
            }

            { // application data
                var context = _provider.GetService<ApplicationDatabaseContext>();
                context.Should().NotBeNull();
                context!.Users.Add(new User
                {
                    Username = string.Empty, // <- should cause error
                    Password = password,
                    Machines =
                    [
                        new MachineModel
                        {
                            Hwid = hwid,
                            DisplayName = string.Empty,
                            DiscordBotToken = string.Empty
                        }
                    ]
                });
                context.SaveChanges();
            }

            var authProvider = _provider.GetService<IDesktopLoginService>();
            authProvider.Should().NotBeNull();

            var result = await authProvider!.LoginAsync(new DesktopLoginRequest
            {
                Username = username,
                Password = password,
                DisplayWidth = width,
                DisplayHeight = height,
                Hwid = hwid
            });

            result.HasError().Should().Be(true);
        }
    }
}
