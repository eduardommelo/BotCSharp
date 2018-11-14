using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop
{
    internal static class Global
    {
        internal static DiscordSocketClient Cliente{ get; set; }
        internal static ulong MenssagemToTrack { get; set; }
    }
}
