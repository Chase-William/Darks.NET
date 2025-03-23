using Darks.Core.Common;
using Darks.Core.Models.Inventory;
using Darks.Core.Models.ParasaurAlarm;
using Darks.Core.ViewModels.ParasaurAlarm;
using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Infrastructure.Providers.Inventory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.ParasaurAlarm;

internal class ParasaurAlarmConfigProvider(
    ILogger <ParasaurAlarmConfigProvider> logger,
    HttpClient client) : IParasaurAlarmConfigProvider
{
    const string PARASAUR_ALARM_URI = "ParasaurAlarmConfig";
    private readonly ILogger<ParasaurAlarmConfigProvider> _logger = logger;
    private readonly HttpClient _client = client;

    public async Task<ParasaurAlarmConfigViewModel> GetConfigAsync()
    {
        var res = await _client.GetAsync(PARASAUR_ALARM_URI);

        var result = await res.Content.ReadFromJsonAsync<Result<ParasaurAlarmConfigViewModel>>();

        if (res.IsSuccessStatusCode)
        {
            if (result is null)
            {
                // return Result<ParasaurAlarmConfigViewModel>.Failure("Failed to deserialize the response from the Darks.API.");
            }
            return result.Data;
        }

        if (result is null)
        {
            // return Result<ParasaurAlarmConfigViewModel>.Failure("Reading json from web response was null.");
        }

        if (!string.IsNullOrEmpty(res.ReasonPhrase))
            result.ErrorMessages.Add(res.ReasonPhrase);
        return result.Data;
    }
}
