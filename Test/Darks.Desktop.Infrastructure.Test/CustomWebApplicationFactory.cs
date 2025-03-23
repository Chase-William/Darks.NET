using Darks.API.Infrastructure.Data;
using Darks.API.Logic.Interfaces.Auth;
using Darks.API.Logic.Services.Auth;
using Darks.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Darks.Desktop.Infrastructure.Test;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> 
    where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {                               
        builder.ConfigureServices((services) =>
        {
            // Remove the default db
            var dbContextDescriptor = services
                .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ConfigDatabaseContext>));
            services.Remove(dbContextDescriptor);

            services.AddSingleton(Substitute.For<ILogger<DesktopClientTokenProvider>>());
            services.AddSingleton<IDesktopAuthTokenProvider, DesktopClientTokenProvider>();

            // Add our in-memory test db
            //services.AddDbContextFactory<IConfigDatabaseContext, ConfigDatabaseContext>(options =>
            //{
            //    options.UseInMemoryDatabase(new Guid().ToString());
            //});

            services.AddDbContextFactory<ConfigDatabaseContext>(options =>
            {
                options.UseSqlite("DataSource=:memory:");
            });

            //var provider = services.BuildServiceProvider();
            //using var scope = provider.CreateScope();
            //var db = scope.ServiceProvider.GetRequiredService<ConfigDatabaseContext>();
            //var t = db.Resolutions.Add(ConfigTestDataProvider.Data.Resolution);
            //Console.WriteLine();
            
        });             

        builder.UseEnvironment("Development");
    }

    public HttpClient CreateAuthenticatedDesktopClient()
    {
        var client = CreateClient();

        var token = Services.GetRequiredService<IDesktopAuthTokenProvider>()!
            .GenerateDesktopClientJWT(
                "...",
                new Core.Models.Account.Machine(),
                ConfigTestDataProvider.Data.Resolution);

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        client.BaseAddress = new Uri("https://localhost:7185/api/");

        return client;
    }
}

