using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Administracao
{
   public  class CommandCargo : ModuleBase<SocketCommandContext>
    {
        [Command("cargo")]
        [RequireUserPermission(Discord.GuildPermission.ManageRoles)]
        public async Task cargoUser(SocketUser username,SocketRole cargo)
        {

            try
            {
                EmbedBuilder bd = new EmbedBuilder();
                var usuario = Context.Guild.GetUser(username.Id);
                var cargoUsuario = Context.Guild.Roles.FirstOrDefault(x => x.Name == "👥 Membros");
                var cargoEquipe = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Equipe Habbop");

                // cargos lista
                var locutor = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🎤 Locutor(es)");
                var embaixador = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🔰Embaixador(es)");
                var moderador = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🔰 Moderador(es)");
                var administrador = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🛡️ Administrador(es)");
                var gerente = Context.Guild.Roles.FirstOrDefault(x => x.Name == "🎖️ Gerente(s)");

                // pegar o usuário desejado


                // mensagens que deverão ser mostrada
                string mensagem = "cargo não definido";
                var channelCargo = Context.Guild.GetTextChannel(469193373647896586);

                if (cargo.Equals("lista"))
                {
                    bd.WithTitle("Lista de Parametros");
                    bd.WithDescription("Por favor informe um dos parâmetros disponpiveis para adicionar o usuário ao cargo.");
                    bd.AddInlineField("tentativa uso do comando", $"{Context.User.Mention}");
                    bd.AddInlineField("Cargos disponíveis", "```locutor, gerente, embaixador, moderador, administrador, gerente´´´");
                    await Context.Message.DeleteAsync();

                    await ReplyAsync("", false, bd.Build());


                }
                if (cargo.Equals("🎤 Locutor(es)"))
                {
                    await usuario.AddRoleAsync(locutor);
                    await usuario.AddRoleAsync(cargoEquipe);
                    await usuario.RemoveRoleAsync(cargoUsuario);

                    mensagem = "locutor";
                    bd.WithDescription($"O usuário {usuario.Mention} foi adicionado ao cargo {mensagem} com sucesso :white_check_mark: ");
                    bd.WithColor(Color.Green);
                    const int delay = 5000;
                    var m = await this.ReplyAsync("", false, bd.Build());
                    await Task.Delay(delay);
                    await m.DeleteAsync();
                    await channelCargo.SendMessageAsync($"{username}  é a mais novo(a) {mensagem} ! :smile:");
                }
                if (cargo.Name.Equals("🔰Embaixador(es)"))
                {
                    await usuario.AddRoleAsync(embaixador);
                    await usuario.AddRoleAsync(cargoEquipe);
                    await usuario.RemoveRoleAsync(cargoUsuario);
                    mensagem = "embaixador";
                    bd.WithDescription($"O usuário {usuario.Mention} foi adicionado ao cargo {mensagem} com sucesso :white_check_mark: ");
                    bd.WithColor(Color.Green);
                    const int delay = 5000;
                    var m = await this.ReplyAsync("", false, bd.Build());
                    await Task.Delay(delay);
                    await m.DeleteAsync();
                    await channelCargo.SendMessageAsync($"{usuario.Mention}  é a mais novo(a) {mensagem} ! :smile:");
                }
                if (cargo.Name.Equals("🔰 Moderador(es)"))
                {
                    await usuario.AddRoleAsync(moderador);
                    await usuario.AddRoleAsync(cargoEquipe);
                    await usuario.RemoveRoleAsync(cargoUsuario);
                    mensagem = "moderador";
                    bd.WithDescription($"O usuário {usuario.Mention} foi adicionado ao cargo {mensagem} com sucesso :white_check_mark: ");
                    bd.WithColor(Color.Green);
                    await Context.Message.DeleteAsync();
                    const int delay = 5000;
                    var m = await this.ReplyAsync("", false, bd.Build());
                    await Task.Delay(delay);
                    await m.DeleteAsync();
                    await channelCargo.SendMessageAsync($"{usuario.Mention}  é a mais novo(a) {mensagem} ! :smile:");
                }
                if (cargo.Name.Equals("🛡️ Administrador(es) "))
                {
                    await usuario.AddRoleAsync(administrador);
                    await usuario.AddRoleAsync(cargoEquipe);
                    await usuario.RemoveRoleAsync(cargoUsuario);
                    mensagem = "administrador";
                    await Context.Message.DeleteAsync();
                    bd.WithDescription($"O usuário {usuario.Mention} foi adicionado ao cargo {mensagem} com sucesso :white_check_mark: ");
                    bd.WithColor(Color.Green);
                    const int delay = 5000;
                    var m = await this.ReplyAsync("", false, bd.Build());
                    await Task.Delay(delay);
                    await m.DeleteAsync();
                    await channelCargo.SendMessageAsync($"{usuario.Mention}  é a mais novo(a) {mensagem} ! :smile:");
                }
                if (cargo.Name.Equals("🎖️ Gerente(s)"))
                {
                    await usuario.AddRoleAsync(gerente);
                    await usuario.AddRoleAsync(cargoEquipe);
                    await usuario.RemoveRoleAsync(cargoUsuario);
                    mensagem = "gerente";
                    bd.WithDescription($"O usuário {usuario.Mention} foi adicionado ao cargo {mensagem} com sucesso :white_check_mark: ");
                    bd.WithColor(Color.Green);
                    await Context.Message.DeleteAsync();
                    const int delay = 5000;
                    var m = await this.ReplyAsync("", false, bd.Build());
                    await Task.Delay(delay);
                    await m.DeleteAsync();
                    await channelCargo.SendMessageAsync($"{usuario.Mention}  é a mais novo(a) {mensagem} ! :smile:");
                }
               else
                {
                    bd.WithTitle("Error Mensagem");
                    bd.WithDescription("Por favor informe um dos parâmetros disponíveis para adicionar o usuário ao cargo.");
                    bd.WithColor(Color.Red);
                    bd.AddInlineField("tentativa uso do comando", $"{Context.User.Mention}");
                    bd.AddInlineField("Cargos disponíveis", "```locutor, gerente, embaixador, moderador, administrador, gerente```");
                    await Context.Message.DeleteAsync();

                    await ReplyAsync("", false, bd.Build());


                }
                var canalLog = Context.Guild.GetTextChannel(472590145774813185);
                await canalLog.SendMessageAsync($"O usuário(a) {Context.User.Username} adicionou o cargo {mensagem} no usuário {usuario.Username}");
        
            }catch (Exception ex)
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
