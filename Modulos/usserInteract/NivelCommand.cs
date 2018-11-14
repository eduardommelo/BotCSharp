using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Usuarios
{
    public class NivelCommand : ModuleBase<SocketCommandContext>
    {
        [Command("mrank")]
    public async Task meuRank(uint xp)
    {
        uint level = (uint)Math.Sqrt(xp / 500);
            await Context.Channel.SendMessageAsync("nível : " + level);


    }
    }
}
