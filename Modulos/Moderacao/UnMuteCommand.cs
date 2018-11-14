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
    public class UnMuteCommand : ModuleBase<SocketCommandContext>
    {
        [Command("unmute")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task unmute(SocketUser username)
        {
            try
            {
                var usuario = Context.Guild.GetUser(username.Id);
                var roles = Context.Guild.Roles.FirstOrDefault(x => x.Name == "👥 Membros");
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Silenciado");
                await usuario.RemoveRoleAsync(role);
                await usuario.AddRoleAsync(roles);

                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}, usuario  {username} desmutado com suceso! :white_check_mark: ");
                await Task.Delay(delay);
                await m.DeleteAsync();

                EmbedBuilder bd = new EmbedBuilder();
                var canalTribunal = Context.Guild.GetTextChannel(469194320965271552);

                bd.WithTitle($"Usuário : {usuario.Username}");
                bd.WithColor(139, 0, 139);
                bd.WithThumbnailUrl($"{usuario.GetAvatarUrl()}");
                bd.WithDescription($"***Usuário desmutado*** :smile: \n por favor obedeça as regras {usuario.Mention}");

                await canalTribunal.SendMessageAsync("", false, bd.Build());
            }
            catch(Exception ex)
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
