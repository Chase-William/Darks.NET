using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Discord
{
    public class DiscordSettingsBase : Model
    {
        public string Token { get; set; }
        public ulong DiscordId { get; set; }

        /// <summary>
        /// Subject to change.
        /// </summary>
        public ulong Server2224TribeLogChannelId { get; set; }

        public ulong AlarmChannelId { get; set; }

        public ulong DiscordErrorsChannelId { get; set; }
        public ulong WorkerUpdatesChannelId { get; set; }
        public ulong GlobalJobUpdateChannelId { get; set; }
        public ulong MissingBedChannelId { get; set; }
    }
}
