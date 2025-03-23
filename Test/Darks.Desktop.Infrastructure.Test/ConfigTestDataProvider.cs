using Darks.Core.Models;
using Darks.Core.Models.Account;
using Darks.Core.Models.Inventory;
using Darks.Core.Models.ParasaurAlarm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Desktop.Infrastructure.Test
{
    public class ConfigTestDataModel
    {
        public Resolution Resolution { get; set; }
        public InventoryScreenConfigModel InventoryScreenConfig { get; set; }
        public ParasaurAlarmScreenConfigModel ParasaurAlarmScreenConfig { get; set; }
    }

    public static class ConfigTestDataProvider
    {
        public static ConfigTestDataModel Data { get; private set; }

        static ConfigTestDataProvider()
        {
            Data = JsonConvert.DeserializeObject<ConfigTestDataModel>(File.ReadAllText("config.data.json"));
        }       
    }
}
