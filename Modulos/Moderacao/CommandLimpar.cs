using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{

    public class CommandLimpar : ModuleBase<SocketCommandContext>
    {
        [Command("limpar", RunMode = RunMode.Async)]
        [Summary("Deleta as mensagens especifícas.")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task PurgeChat(uint amount)
        {
            if (amount > 800)
            {

                await ReplyAsync($"{Context.User.Mention}, você não tem permissão de limpar acima de 800 mensagens!");
                await Context.Message.DeleteAsync();

               
            }
            else
            {
                var messages = await this.Context.Channel.GetMessagesAsync((int)amount + 1).Flatten();
                await this.Context.Channel.DeleteMessagesAsync(messages);
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}. Limpo com sucesso, esta mensagem será apagada em  {delay / 1000} segundos.");
                await Task.Delay(delay);
                await m.DeleteAsync();

                await Context.Guild.GetTextChannel(472590145774813185).SendMessageAsync($"O usuário {Context.User.Username} executou o comando limpar, limpando " + amount + " mensagens.");

            


                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"O usuário {Context.User.Username} limpou o canal {Context.Channel.Name}");
            }
          

        }

    }
}
