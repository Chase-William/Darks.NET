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
using Microsoft.EntityFrameworkCore;
using Darks.API.Logic.Mappers.Inventory;
using FluentAssertions.Common;

namespace Darks.Desktop.Infrastructure.Test.Tests.Providers.Inventory
{
    public class InventoryConfigProviderTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public InventoryConfigProviderTests(CustomWebApplicationFactory<Program> factory)
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

                ConfigTestDataProvider.Data.InventoryScreenConfig.Resolution = ConfigTestDataProvider.Data.Resolution;
                await db.InventoryScreenConfigs.AddAsync(ConfigTestDataProvider.Data.InventoryScreenConfig);
                await db.SaveChangesAsync();
            }

            var inventoryConfigProvider = new InventoryConfigProvider(
                Substitute.For<ILogger<InventoryConfigProvider>>(),
                client);

            // Test
            var result = await inventoryConfigProvider.GetConfigAsync();

            // Results
            result.HasError().Should().Be(false);
            //result.Data.Should().BeEquivalentTo(_factory.DataProvider.InventoryScreenConfig.ToViewModel());
        }
    }
}
