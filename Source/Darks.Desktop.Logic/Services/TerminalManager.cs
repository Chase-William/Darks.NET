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
    public class TerminalManager(
        ILogger<TerminalManager> logger,
        ITerminalSettingsProvider settingsProvider)
    {
        private readonly ILogger<TerminalManager> _logger = logger;
        private readonly ITerminalSettingsProvider _settingsProvider = settingsProvider;

        /// <summary>
        /// Only Az09 and a few other characters like white space we passed as strings here.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task Write(string text)
        {
            _logger.LogInformation("Writing {Text} to terminal.", text);
            var settings = await _settingsProvider.GetSettingsAsync();
            // Open terminal
            await Input.SendGame(settings.TerminalToggleKey.ToKey());
            await Task.Delay(1000);
            // Input text

            var keys = new Key[text.Length];
            for (int index = 0; index < text.Length; index++)            
                if (Enum.TryParse(text[index].ToString(), out Key key))
                    keys[index] = key;


            //
            //  The terminal will only receive Key types via Input.Send().. only keys
            //

            Input.Send(keys);
            await Task.Delay(1000);
            // Enter the terminal and closes it
            await Input.SendGame(Key.Enter);
            await Task.Delay(500);
        }   
    }
}
