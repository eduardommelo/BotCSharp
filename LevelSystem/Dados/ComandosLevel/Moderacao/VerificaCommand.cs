using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.LevelSystem.Dados.ComandosLevel.Moderacao
{
    public class VerificaCommand : ModuleBase<SocketCommandContext>
    {
        [Command("vuser")]
        public async Task verificacaoUser(SocketUser user)
        {
            try
            {
                EmbedBuilder build = new EmbedBuilder();

              
                build.WithTitle($"Verificação : {user.Username}");
                build.WithColor(Color.Blue);
                build.AddInlineField("Conta criada", user.CreatedAt);
                await Context.Message.DeleteAsync();
                await Context.Channel.SendMessageAsync($"{Context.User.Mention}", false, build.Build());
            }catch (Exception ex)
            {

                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}. Erro ao encontrar este usuário :x:");
                await Task.Delay(delay);
                await m.DeleteAsync();
            }
        }
    }
}
