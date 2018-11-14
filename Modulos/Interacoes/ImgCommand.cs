using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{
  
    public class ImgCommand : ModuleBase<SocketCommandContext>
    {
        [Command("avatar")]
        public async Task eduardo(SocketUser user) {

            try
            {



                var usuario = Context.Guild.GetUser(user.Id);

                EmbedBuilder builds = new EmbedBuilder();
                builds.WithTitle(":camera_with_flash:Abrir a foto em uma nova guia");
                builds.WithColor(139, 0, 139);
                builds.WithAuthor($"Foto de {usuario.Username}");
                builds.WithUrl($"{usuario.GetAvatarUrl(size: 2048)}");
                builds.WithImageUrl($"{usuario.GetAvatarUrl(size: 2048)}");

                await ReplyAsync("", false, builds.Build());
            }
            catch (Exception ex)
            {

                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}, Hmmmm :frowning:, houve algum erro ao encontrar este usuário, tente pegar pelo id dele :smile: ");
                await Task.Delay(delay);
                await m.DeleteAsync();

            }
        }

    }
        

    
}
