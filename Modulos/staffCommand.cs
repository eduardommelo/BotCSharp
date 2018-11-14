using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{
    public class staffCommand : ModuleBase<SocketCommandContext>
    {
        [Command("comandos")]
        public async Task botStaff()
        {
            EmbedBuilder bd = new EmbedBuilder();

            bd.WithTitle("Comandos staff");
            bd.WithColor(Color.Blue);
            bd.WithDescription("***mutar <name> <motivo>*** mutar um usuário especifico  \n" +
                "***kick <name> <motivo>*** expulsar um membro específico. \n" +
                "***ban <name> <motivo>*** banir um usuário escpecífico permanente. \n" +
                "***mutar <name> <motivo>*** mutar o usuário específico. \n" +
                "***limpar <quantia>*** limpar mensagem na sala que está. \n" +
                "***pm <name> <mensagem>*** mandar uma mensagem para um usuário especifico . \n" +
                "***imagem <url>*** setar uma imagem para DiscordMessage. \n" +
                "***dm <texto>*** mandar um alerta geral para todos os usuários via pm. \n" +
                "***rcargo <name>*** remover cargo de um usuário específico. \n" +
                "***dar <tipo> diamantes/xp <quantia>*** enviar diamantes/xp ao usuário especifico . \n" +
                "***cargo <username> <cargo>*** adicionar um usuário específico ao cargo. \n");

            var usuario = Context.Guild.GetUser(Context.User.Id);
            await usuario.SendMessageAsync("", false, bd.Build());
            await Context.Message.DeleteAsync();
            const int delay = 5000;
            var m = await this.ReplyAsync($"{Context.User.Mention}, Foi enviado uma lista de moderação no seu pm (Mensagem privada):smile: ");
            await Task.Delay(delay);
            await m.DeleteAsync();
    

        }
    }
}
