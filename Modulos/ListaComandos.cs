using Discord;
using Discord.Commands;
using Discord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{
    public class ListaComandos : ModuleBase<SocketCommandContext>
    {
        [Command("ajuda")]
        public async Task CommandsList()
        {
          

            EmbedBuilder bd = new EmbedBuilder();

            var usuario = Context.Guild.GetUser(Context.User.Id);
            bd.WithTitle("Lista de comandos");
            bd.WithImageUrl("https://i.imgur.com/gR5PWin.png");
            bd.WithColor(Color.Blue);
            bd.WithDescription($"Olá {Context.User.Mention} :smile: , meu nome é {Context.Client.CurrentUser} sou responsável por cuidar do servidor, estou sempre ligado o que ja por dentro, " +
                $"minha função é manter vocês interagidos com minhas funcionalidades de interação e é claro, moderação, estarei te notificando de promoções ativas, de novos eventos que vão ocorrer" +
                $"então chega de enrolação e vamos aos comandos :smile:");
            bd.AddInlineField("Comandos de Interação", "***meme <imagem url> / <lista> ver os que já estão adicionado <legenda>*** \n" +
                "```Gerar uma imagem com legenda ao topo, para que você possa fazer mini montagens :smile:``` \n" +
                "***ship <mention1> <mention2>*** \n ``` Utilize para ver quem se combinam mais, eu irei está juntando seus nomes e a probabilidade de se darem bem juntos. ``` \n" +
                "***piada*** \n" +
                "```quer dar gargalhadas?! então faça eu contar uma dois 8 piadas que tenho aqui armazenado, lembrando que não prometo que todos são do seu gosto em. ``` \n" +
                "***perfil*** \n ``` visualizar seu perfil. ```\n" +
                "***missao <texto>*** \n ```Defina uma frase no seu perfil. ``` \n " +
                "***avatar <name>*** \n ```Amplie a imagem do seu amigo``` \n");
            bd.AddInlineField("Comando Info", "***sobre*** \n ```Conto um pouco sobre mim hihi e como fui criado.``` \n" +
                "***servidor*** ```puxe informações gerais do servidor.```");
            bd.AddInlineField("+Info Bot", "``` O Frank aceita dois tipos de prefixos o vírgula e dois pontos, caso abuse um dos comandos por spam, poderá ser punido ou receberá um aviso do bot.``` ");

            await usuario.SendMessageAsync("", false, bd.Build());
            await Context.Message.DeleteAsync();
            const int delay = 5000;
            var m = await this.ReplyAsync($"{Context.User.Mention}, Mandei uma pequena lista no seu pm do que eu posso fazer :smile: ");
            await Task.Delay(delay);
            await m.DeleteAsync();






        }
    }
}
