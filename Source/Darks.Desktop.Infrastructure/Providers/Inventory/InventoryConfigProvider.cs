using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using Darks.Core.ViewModels.Inventory;
using Darks.Desktop.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Inventory
{
    internal class InventoryConfigProvider(
        ILogger<InventoryConfigProvider> logger,
        HttpClient client) : IInventoryConfigProvider
    {
        const string INVENTORY_URI = "InventoryConfig";
        private readonly ILogger<InventoryConfigProvider> _logger = logger;
        private readonly HttpClient _client = client;

        public async Task<InventoryConfigViewModel> GetConfigAsync()
        {
            var res = await _client.GetAsync(INVENTORY_URI);

            var result = await res.Content.ReadFromJsonAsync<Result<InventoryConfigViewModel>>();

            if (res.IsSuccessStatusCode)
            {
                if (result is null)
                {
                    // return Result<InventoryConfigViewModel>.Failure("Failed to deserialize the response from the Darks.API.");
                }
                return result.Data;
            }

            if (result is null)
            {
                // return Result<InventoryConfigViewModel>.Failure("Reading json from web response was null.");
            }

            if (!string.IsNullOrEmpty(res.ReasonPhrase))
                result.ErrorMessages.Add(res.ReasonPhrase);
            return result.Data;     
        }
    }
}
