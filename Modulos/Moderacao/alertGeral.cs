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
   
    public class alertGeral : ModuleBase<SocketCommandContext>
    {

        [Command("alert"), RequireBotPermission(GuildPermission.ManageChannels)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task testesEdu([Remainder]string message)
        {
            if (Context.Channel.Id == 469233496485920770 || Context.Channel.Id == 469238300725477380)
            {

                EmbedBuilder embed = new EmbedBuilder();
           
                embed.WithTitle("Mensagem de Habbop Hotel");
                embed.WithDescription(message);
                embed.WithAuthor("", Context.User.GetAvatarUrl());
                embed.WithAuthor($"{Context.User.Username}", Context.User.GetAvatarUrl());
                embed.WithColor(139, 0, 139);

                await  Context.Guild.GetTextChannel(469193373647896586).SendMessageAsync("", false, embed.Build());
                await Context.Message.DeleteAsync();

                await Context.Guild.GetTextChannel(472590145774813185).SendMessageAsync($"O usuário {Context.User.Username} executou o comando alert enviando a seguinte mensagem \n" +
                   "[*" +  message + "*]");

                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"O usuário {Context.User.Username} executou alert");
            }
            else {

                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}. Por favor, execute os comandos na sala de comandos-bot . (Está mensagem será apagada em   {delay / 1000} segundos.)");
                await Task.Delay(delay);
                await m.DeleteAsync();
            }
        
        }

    
    }
}
