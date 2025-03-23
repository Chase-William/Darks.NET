using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Darks.API.Infrastructure;
using Darks.API.Logic.Services.Auth;
using Darks.API.Logic.Services.Auth.Login;
using Darks.API.Logic.Interfaces.Auth;
using Darks.API.Logic.Interfaces.Auth.Login;
using Darks.API.Logic.Interfaces;
using Darks.API.Logic.Services.Inventory;
using Darks.API.Logic.Services.ParasaurAlarm;

namespace Darks.API.Logic
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureAPILogicServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IDesktopAuthTokenProvider, DesktopClientTokenProvider>();
            services.AddTransient<IWebTokenProvider, WebAuthTokenProvider>();
            services.AddTransient<IWebLoginService, WebLoginService>();
            services.AddTransient<IDesktopLoginService, DesktopLoginService>();

            services.AddScoped<IInventoryConfigService, InventoryConfigService>();
            services.AddScoped<IParasaurConfigService, ParasaurAlarmConfigService>();

            services.ConfigureAPIInfrastructureServices(config);

            return services;
        }
    }
}
