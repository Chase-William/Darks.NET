using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Jobs
{
    public abstract class JobBlueprint : Model
    {
        public string ServerName { get; set; }
        public ulong UpdateChannelId { get; set; }

        public override string ToString()
        {
            return $"Job Type: {GetType().Name} with Id: {Id}";
        }
    }
}
