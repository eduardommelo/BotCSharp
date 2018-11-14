using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Administracao
{
    public class MessageAllCommand : ModuleBase<SocketCommandContext> 
    {
        [Command("dm")]
        public async Task dMessage()
        {
            foreach (SocketRole role in ((SocketGuildUser)Context.Message.Author).Roles)
            {
                Console.WriteLine(role.Name);
            }
        }
    }
}
