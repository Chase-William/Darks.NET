﻿using Darks.Core.Models.Configuration;
using Darks.Desktop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Providers.Configuration
{
    internal class AppConfigurationProvider : IAppConfigurationProvider
    {
        public T GetConfiguration<T>()
        {
            throw new NotImplementedException();
        }
    }
}
