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
    public class RemoveCargoCommand : ModuleBase<SocketCommandContext>
    {
        [Command("rcargo")]
        [RequireUserPermission(Discord.GuildPermission.ManageRoles)]
        public async Task removerCargo(SocketUser username)
        {

            try
            {
                var usuario = Context.Guild.GetUser(username.Id);
                var cargoEquipe = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Equipe Habbop");
                var cargoUsuario = Context.Guild.Roles.FirstOrDefault(x => x.Name == "👥 Membros");
                // cargos lista
                var embaixador = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🔰Embaixador(es) ");
                var moderador = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🔰 Moderador(es)");
                var administrador = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🛡️ Administrador(es)");
                var gerente = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🎖️ Gerente(s)");

                await usuario.RemoveRoleAsync(embaixador);
                await usuario.RemoveRoleAsync(moderador);
                await usuario.RemoveRoleAsync(administrador);
                await usuario.RemoveRoleAsync(gerente);
                await usuario.RemoveRoleAsync(cargoEquipe);
                await usuario.AddRoleAsync(cargoUsuario);

                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"O cargo do usuário {usuario.Mention} foi removido com sucesso :white_check_mark: ");
                await Task.Delay(delay);
                await m.DeleteAsync();
                var canalLog = Context.Guild.GetTextChannel(472590145774813185);
                var canalChat = Context.Guild.GetTextChannel(469193373647896586);

                await canalChat.SendMessageAsync($"O usuário(a) {usuario.Username} foi removido(a) do cargo  :frowning: ");
                await canalLog.SendMessageAsync($"O usuário(a) {Context.User.Username} removeu o cargo do usuário {usuario.Username}");

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
