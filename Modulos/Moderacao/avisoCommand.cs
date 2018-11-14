using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Moderacao
{
    public class avisoCommand : ModuleBase<SocketCommandContext>
    {
        [Command("avisar")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task avisos(SocketUser usuario, [Remainder]string mensagem = "não específico")
        {
            try
            {
                var userAccount = LevelSystem.Dados.UsuarioDado.GetUsuarioDados((Context.Guild.GetUser(usuario.Id)));
                userAccount.NumberOfWarning++;
                LevelSystem.Dados.UsuarioDado.SaveAccounts();

                var name = Context.Guild.GetUser(usuario.Id);

                EmbedBuilder bd = new EmbedBuilder();
                EmbedBuilder bds = new EmbedBuilder();
                bd.WithTitle("Mensagem de aviso");
                bd.WithThumbnailUrl($"{Context.User.GetAvatarUrl()}");
                bd.WithDescription("Você recebeu um aviso com a seguinte mensagem: \n" +
                    $"```{mensagem}```");
                bd.AddInlineField("Avisos Que você recebeu:", $"{userAccount.NumberOfWarning}");
                bd.AddInlineField($"Autor que enviou o aviso: ", $"{Context.User.Username}");

                var canalTribunal = Context.Guild.GetTextChannel(469194320965271552);
                bds.WithAuthor($"Avisado por  : {Context.Message.Author}");
                bds.WithTitle($":x: {name.Username} foi avisado!");
                bds.WithColor(139, 0, 139);
                bds.WithThumbnailUrl($"{name.GetAvatarUrl(size: 2048)}");
                bds.WithDescription($"***Motivo***``` {mensagem} ```\n" +
                    $"***ID*** : ```{name.Id}``` ");



                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention},O usuário {usuario} foi avisado com sucesso! :smile: ");
                await Task.Delay(delay);
                await m.DeleteAsync();

                await canalTribunal.SendMessageAsync("", false, bds.Build());

                await name.SendMessageAsync("", false, bd.Build());

           

                if (userAccount.NumberOfWarning >= 3)
                {
                    bd.WithTitle("Mensagem de aviso");
                    bd.WithThumbnailUrl($"{Context.User.GetAvatarUrl()}");
                    bd.WithDescription("Você foi punido por: \n" +
                        $"```{mensagem}```");
                    bd.AddInlineField("Avisos Que você recebeu:", $"{userAccount.NumberOfWarning}");
                    bd.AddInlineField($"Autor que enviou o aviso: ", $"{Context.User.Username}");
               
                    await name.SendMessageAsync("", false, bd.Build());
                    await name.KickAsync();
                }
            }
            catch (Exception ex) {

                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention},:x: Houve um erro ao encontar este usuário, no caso tente procura-lo por ID. :smile: ");
                await Task.Delay(delay);
                await m.DeleteAsync();
            }
        }
    }
}
