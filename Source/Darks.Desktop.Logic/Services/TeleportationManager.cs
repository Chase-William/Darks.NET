using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Logic.Services
{
    public class TeleportationManager(ITeleportationSettingsProvider settingsProvider)
    {
        private readonly ITeleportationSettingsProvider _settingsProvider = settingsProvider;
    }
}
