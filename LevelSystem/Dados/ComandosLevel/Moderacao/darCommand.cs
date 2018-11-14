using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.LevelSystem.Dados.ComandosLevel.Moderacao
{
    public class darCommand : ModuleBase<SocketCommandContext>
    {
        [Command("dar")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task darStaff(string username, string tipo, uint quantia)
        {
            try
            {
                var account = UsuarioDado.GetUsuarioDados(Context.Guild.GetUser(Convert.ToUInt64(username.Replace("@", "").Replace("<", "").Replace(">", ""))));
                if (tipo.Equals("xp"))
                {
                    account.XP += quantia;
                    UsuarioDado.SaveAccounts();
                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} você deu {quantia} de xp ao usuário {username} com sucesso! :white_check_mark: ");
                }
                if (tipo.Equals("diamantes"))
                {
                    account.Points += quantia;
                    UsuarioDado.SaveAccounts();
                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} você deu {quantia} diamantes ao  {username} com sucesso! :white_check_mark: ");
                }
            }
            catch (Exception ex)
            {
                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention},:x: Houve um erro ao encontar este usuário, no caso tente procura-lo por ID. :smile: ");
                await Task.Delay(delay);
                await m.DeleteAsync();
                
            }
        }
    }
}
