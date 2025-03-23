using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using NSubstitute;

using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Infrastructure.Providers.Inventory;
using FluentAssertions;
using Darks.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Darks.API.Logic.Interfaces.Auth;
using Darks.API.Logic.Services.Auth;
using Darks.API.Infrastructure.Data;
using Darks.Core.Models;
using Darks.Core.Models.Inventory;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Darks.Desktop.Infrastructure.Providers.ParasaurAlarm;
using Microsoft.EntityFrameworkCore;
using Darks.API.Logic.Mappers.ParasaurAlarm;

namespace Darks.Desktop.Infrastructure.Test.Tests.Providers.ParasaurAlarm
{
    public class ParasaurAlarmConfigProviderTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly ServiceProvider _provider;

        public ParasaurAlarmConfigProviderTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void FetchesInventoryConfigCorrectly()
        {
            var client = _factory.CreateAuthenticatedDesktopClient();

            var scope = _factory.Services.CreateAsyncScope();
            using (var db = scope.ServiceProvider.GetRequiredService<ConfigDatabaseContext>())
            {
                await db.Database.EnsureDeletedAsync();
                await db.Database.EnsureCreatedAsync();

                ConfigTestDataProvider.Data.ParasaurAlarmScreenConfig.Resolution = ConfigTestDataProvider.Data.Resolution;
                await db.ParasaurAlarmScreenConfigs
                    .AddAsync(ConfigTestDataProvider.Data.ParasaurAlarmScreenConfig);
                await db.SaveChangesAsync();
            }

            var parasaurAlarmConfigProvidier = new ParasaurAlarmConfigProvider(
                Substitute.For<ILogger<ParasaurAlarmConfigProvider>>(),
                client);

            // Test
            var result = await parasaurAlarmConfigProvidier.GetConfigAsync();

            // Results
            result.HasError().Should().Be(false);
            //result.Data.Should().BeEquivalentTo(_factory.DataProvider.ParasaurAlarmScreenConfig.ToViewModel());
        }
    }
}
