using Discord.Commands;
using Habbop.LevelSystem.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Interacoes
{
    public class missaoCommand : ModuleBase<SocketCommandContext>
    {
        [Command("missao")]
        public async Task missao([Remainder]string desc)
        {
            var account = LevelSystem.Dados.UsuarioDado.GetUsuarioDados(Context.User);
            account.missao = desc;
            UsuarioDado.SaveAccounts();
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{Context.User.Mention} missão alterada / adicionada com sucesso!");
            
        }
    }
}
