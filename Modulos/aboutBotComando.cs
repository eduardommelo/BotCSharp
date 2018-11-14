using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{
    public class aboutBotComando : ModuleBase<SocketCommandContext>
    {
        [Command("sobre")]
        public async Task aboutHabbop()
        {
            EmbedBuilder bd = new EmbedBuilder();

            var usuario = Context.Guild.GetUser(Context.User.Id); 

            bd.WithTitle($"Sobre bot {Context.Client.CurrentUser.Username}");
            bd.WithColor(Color.Blue);
            bd.WithThumbnailUrl("https://cdn.discordapp.com/attachments/456641846869884929/477296827968913428/Sem_Titulo-2.png");
            bd.WithImageUrl("https://cdn.discordapp.com/attachments/456641846869884929/477285929615360010/bb.png");
            bd.WithDescription("Olá meu nome é ***Frank*** :smile: fui desenvolvido com intuito de \n " +
                "moderar, interagir  e até mesmo tocar algumas músicas legais, mas tem meus amigos\n" +
                " que me dão uma forcinha hehe :smile: fui desenvolvido em C# POO utilizando base ***discord.net API V1.0.2 (API V6)*** " +
                "minhas artes e desenho foi desenvolvido pelo meu amigo favorito :smile: o ***Jon*** e o meu pai é claro " +
                "***Eduardo Melo***, mais conhecido no discord como HomenAco. " +
                "Estou aqui para sempre te servir ajudando você e dando suporte no que você mais precisa :smile: ah... " +
                "e tem mais! irei está de olho em você também viu, pois no caso que você quebre um dos termos da sala regras " +
                "você será punido. :frowning:  Então leia atentamente os nossos termos que tudo ficará bem, caso tenha algum " +
                "problema algum tipo de usuário mau intencionado spamando seu pv, me chame que estarei te ajudando, sou um bot multi-funcionao né? :smile: \n" +
                "fui feito para isso! para tratar de seus problema e brincar com vocês, para você saber o que posso fazer basta " +
                "pedir minha ajuda digitando ,ajuda / :ajuda ***lembrando que aceito 2 prefixos em (,) e (:) então é isso aí :smile: " +
                "tomara que tenha gostado de mim, qualquer coisa estou aí em viu, até mais! ***SE EU TIVER COM ALGUM DEFEITO OU PROBLEMA " +
                "PODE CHAMAR MEU PAI VIU? POIS ELE VAI ESTÁ RESOLVENDO RAPIDINHO ***:smile:");

            await usuario.SendMessageAsync("", false, bd.Build());

            await Context.Message.DeleteAsync();
            const int delay = 5000;
            var m = await this.ReplyAsync($"{Context.User.Mention}. Te mandei no privado um texto feito com amor :heart:  sobre mim :smile:!");
            await Task.Delay(delay);
            await m.DeleteAsync();
        }
    }
}
