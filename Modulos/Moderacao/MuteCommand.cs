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
    public class MuteCommand : ModuleBase<SocketCommandContext>
        
    {
        [Command("mutar")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task mutar(SocketUser user, [Remainder]string motivo ="nenhum motivo")
        {

            try
            {
                var username = Context.Guild.GetUser(user.Id);
                var roles = Context.Guild.Roles.FirstOrDefault(x => x.Name == "👥 Membros");
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Silenciado");

                await username.AddRoleAsync(role);
                await username.RemoveRoleAsync(roles);
                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}, usuario  {user} mutado com suceso! :white_check_mark: ");
                await Task.Delay(delay);
                await m.DeleteAsync();
                EmbedBuilder bd = new EmbedBuilder();
                var canalTribunal = Context.Guild.GetTextChannel(469194320965271552);
                bd.WithAuthor($"Mutado por   : {Context.Message.Author}");
                bd.WithTitle($":x: {username.Username} foi mutado!");
                bd.WithColor(139, 0, 139);
                bd.WithThumbnailUrl($"{username.GetAvatarUrl(size: 2048)}");
                bd.WithDescription($"***Motivo***``` {motivo} ```\n" +
                    $"***ID*** : ```{username.Id}``` ");

                await canalTribunal.SendMessageAsync("", false, bd.Build());

            }
            catch (Exception ex)
            {
                EmbedBuilder builder = new EmbedBuilder();
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
