using Darks.Desktop.Infrastructure.Interfaces;
using Darks.Desktop.Logic.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUtilities;

namespace Darks.Desktop.Logic.Services
{
    public class GenericKeyController(
        ILogger<GenericKeyController> logger,
        IGenericKeySettingsProvider settingsProvider)
    {
        private readonly ILogger<GenericKeyController> _logger = logger;
        private readonly IGenericKeySettingsProvider _settingsProvider = settingsProvider;

        public async Task Use()
        {
            _logger.LogInformation("Attempting to use a target.");
            var config = await _settingsProvider.GetSettingsAsync();
            await Input.SendGame(config.UseKey.ToKey());
        }
    }
}
