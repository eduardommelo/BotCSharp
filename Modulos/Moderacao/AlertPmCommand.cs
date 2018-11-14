using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Habbop.LevelSystem.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{
    public class AlertDMCommand : ModuleBase<SocketCommandContext>
    {
        [Command("pm")]
        [RequireUserPermission(Discord.GuildPermission.ManageMessages)]
        public async Task dmcomando(SocketUser username,[Remainder]string mensagem)
        {
            var usuario = Context.Guild.GetUser(username.Id);
            await Context.Message.DeleteAsync();
            await usuario.SendMessageAsync(mensagem);
        }
    }
}
