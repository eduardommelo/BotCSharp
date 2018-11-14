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
    public class ComandoBan : ModuleBase<SocketCommandContext>
    {
        [Command("ban")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task banirUser(SocketUser name, [Remainder]string rz = "não específicado")
        {
            try {

                var user = Context.Guild.GetUser(name.Id);
              
                EmbedBuilder builder = new EmbedBuilder();

                if (name.IsBot)
                {
                    await Context.Message.DeleteAsync();
                    EmbedBuilder bd = new EmbedBuilder();
                    bd.WithColor(Color.Red);
                    bd.WithDescription($"{Context.User.Mention},:x: ***Erro***: Você não pode banir bots. :smile: ");
                    await ReplyAsync("", false, bd.Build());
                }
                else
                {


                    builder.WithTitle("Mensagem do Servidor");
                    builder.WithColor(Color.Red);
                    builder.WithThumbnailUrl("https://cdn.discordapp.com/attachments/456641846869884929/477296827968913428/Sem_Titulo-2.png");
                    builder.WithDescription("Você foi banido violando as regras do servidor, caso haja algum engano por favor relatar aos staffs do servidor. \n" +
                        $"***Motivo do banimento*** ```{rz}```");


                   // var amount = Context.Guild.GetUser(name.Id);
                   // var messages = await this.Context.Channel.GetMessagesAsync((int)amount + 1).Flatten();
                   // await this.Context.Channel.DeleteMessagesAsync(messages);
                    await user.SendMessageAsync("", false, builder.Build());
                    await Context.Guild.AddBanAsync(user);
                    await Context.Message.DeleteAsync();
                    const int delay = 5000;
                    var m = await this.ReplyAsync($"{Context.User.Mention}, :white_check_mark:  {Context.User.Mention} usuário banido com sucesso!  ");
                    await Task.Delay(delay);
                    await m.DeleteAsync();


                    var canalTribunal = Context.Guild.GetTextChannel(469194320965271552);
                    builder.WithAuthor($"Banido por : {Context.Message.Author}");
                    builder.WithTitle($":x: {user.Username} foi banido!");
                    builder.WithColor(139, 0, 139);
                    builder.WithThumbnailUrl($"{user.GetAvatarUrl(size: 2048)}");
                    builder.WithDescription($"***Motivo***``` {rz} ```\n" +
                        $"***ID*** : ```{user.Id}``` ");

                    await canalTribunal.SendMessageAsync("", false, builder.Build());
                }
            }
            catch (Exception ex)
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.Red);
                builder.WithDescription($"{Context.User.Mention},:x: Houve um erro ao encontar este usuário, no caso tente procura-lo por ID. :smile: ");
                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync("", false, builder.Build());
                await Task.Delay(delay);
                await m.DeleteAsync();


            }
        }


    }
}
