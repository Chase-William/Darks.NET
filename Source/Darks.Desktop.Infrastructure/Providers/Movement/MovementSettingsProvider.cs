using Darks.Core.Models.Movement;
using Darks.Core.ViewModels.Movement;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Movement
{
    internal class MovementSettingsProvider : IMovementSettingsProvider
    {
        public Task<MovementSettingsViewModel> GetSettingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
