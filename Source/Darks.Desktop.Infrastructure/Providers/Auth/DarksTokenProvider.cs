using Darks.Desktop.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Darks.Desktop.Infrastructure.Providers.Auth
{
    internal class DarksTokenProvider : DelegatingHandler, IDarksTokenProvider
    {
        const int TokenRefreshInterval = 50 * 60 * 1000; // Refresh every 50 minutes

        private readonly ILogger<DarksTokenProvider> _logger;
        private readonly ILoginService _loginService;
        private readonly System.Timers.Timer _tokenRefreshTimer = new(TokenRefreshInterval);

        public string DarksToken { get; private set; }

        public DarksTokenProvider(
            ILogger<DarksTokenProvider> logger,
            ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;

            // Update token handler
            _tokenRefreshTimer.Elapsed += async delegate { DarksToken = await RequestNewToken(); };

            // When the user receives a token, store it here.
            _loginService.TokenReceived += token => 
            {
                DarksToken = token;
                _tokenRefreshTimer.Start();
            };

            // TODO: Stop this timer when appropriate
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Add the token to the Authorization header
            if (!string.IsNullOrEmpty(DarksToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", DarksToken);
            }

            // Continue processing the request
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> RequestNewToken()
        {
            // TODO: make reques to Darks.Web endpoint for jwt refresh providing a valid jwt
            throw new NotImplementedException();
        }
    }
}
