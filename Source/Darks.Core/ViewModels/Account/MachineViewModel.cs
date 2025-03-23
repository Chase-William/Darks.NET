using Darks.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.ViewModels.Account
{
    public class MachineViewModel : MachineBase
    {
        public MachineViewModel(MachineModel model)
        {
            base.Id = model.Id;
            base.DisplayName = model.DisplayName;
            base.DiscordBotToken = model.DiscordBotToken;
            base.Hwid = model.Hwid;
        }
    }
}
