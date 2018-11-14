using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Habbop.LevelSystem.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Moderacao
{

    public class DMCommand : ModuleBase<SocketCommandContext>
    {
        [Command("dm")]
        [RequireUserPermission(Discord.GuildPermission.ManageMessages)]
        public async Task dMessage()
        {



      


        }
    
    }
}
