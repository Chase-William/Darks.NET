using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Account
{
    public class User : Model
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<MachineModel> Machines { get; set; }
    }
}
