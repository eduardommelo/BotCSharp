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
    public class kickCommand : ModuleBase<SocketCommandContext>
    {
        [Command("kick")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task kickUsuario(SocketUser username, [Remainder]string razao = "motivo não específicado") {

            try
            {
                if (razao.Equals("")) {

                    razao = "Nenhuma razão específicada";

                }

                EmbedBuilder builder = new EmbedBuilder();

                var usuario = Context.Guild.GetUser(username.Id);

                builder.WithTitle("Mensagem do Servidor");
                builder.WithColor(Color.Red);
                builder.WithThumbnailUrl("https://cdn.discordapp.com/attachments/456641846869884929/477296827968913428/Sem_Titulo-2.png");
                builder.WithDescription("Você foi banido por violar as regras do servidor, caso não tenha violado entre em contato com um dos adm \n\n" +
                    $"Você foi banido pela seguinte razão : ```{razao}```");



                await usuario.SendMessageAsync("", false, builder.Build());

                var canalPunicao = Context.Guild.GetTextChannel(469194320965271552);



                builder.WithAuthor($"Expulso por : {Context.Message.Author}");
                builder.WithTitle($":x: {usuario.Username} foi expulso!");
                builder.WithColor(139, 0, 139);
                builder.WithThumbnailUrl($"{usuario.GetAvatarUrl(size: 2048)}");
                builder.WithDescription($"***Motivo***``` {razao} ```\n" +
                    $"***ID*** : ```{usuario.Id}``` ");

                await canalPunicao.SendMessageAsync("", false, builder.Build());
                usuario.KickAsync();


                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}, Usuário foi expulso com sucesso!:white_check_mark: ");
                await Task.Delay(delay);
                await m.DeleteAsync();

            }
            catch (Exception ex) {
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