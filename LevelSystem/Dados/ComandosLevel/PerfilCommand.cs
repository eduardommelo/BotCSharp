using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Habbop.LevelSystem.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.LevelSystem.Dados.ComandosLevel
{
    public class MeuXPCommand : ModuleBase<SocketCommandContext>
    {
        [Command("perfil")]
        public async Task meusPontos()
        {


      EmbedBuilder bd = new EmbedBuilder();

      var status = $"{Context.User.Status}";
;       
   

       if (status.Equals("DoNotDisturb"))
            {
              status = ":red_circle:  Não pertubar";

            }
            if (status.Equals("Idle"))
            {
                status = ":large_blue_circle:   Ausente";
            }
            if(status.Equals("Offline"))
            {
                status = ":white_circle:    Invisível";
            }
            if(status.Equals("Online"))
            {
                status = ":white_check_mark:  Disponível";
            }
            var cargores = "";

            UsuarioDados account = UsuarioDado.GetUsuarioDados(Context.User);
            foreach (SocketRole role in ((SocketGuildUser)Context.Message.Author).Roles)
            {
                cargores  += " "+ role.Name + ",";
            }
            var idUser = $"```{Context.User.Id}```";
            var idName = $"```{Context.User.Username}```";
            bd.WithTitle($"Perfil de {Context.User}");
            bd.WithColor(Color.Blue);
            bd.WithDescription($"Missão :```{account.missao}```");
            bd.WithThumbnailUrl($"{Context.User.GetAvatarUrl(size:2048)}");
            bd.AddInlineField("Status", status);
            bd.AddInlineField("Jogando", $":video_game: {Context.User.Game}");
            bd.AddInlineField("XP: ", $"```{account.XP}```");
            bd.AddInlineField("Diamantes : ", $"```{account.Points}```");
            bd.AddInlineField("Nome da Conta:", idName);
            bd.AddInlineField("Nível:", $"```{account.levelNumero}```");
            bd.AddInlineField("Avisos", $"```{account.NumberOfWarning}```");
            bd.AddInlineField("Conta criada em", $"{Context.User.CreatedAt}");
            bd.AddInlineField("ID:", idUser);
            bd.AddInlineField("Cargos:", $"***{cargores}***");



            await Context.Channel.SendMessageAsync("", false, bd.Build());

        }
     
    }
}
