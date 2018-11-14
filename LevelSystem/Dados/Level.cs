using Discord.WebSocket;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Habbop.LevelSystem.Dados
{
    internal static class Level
    {
        internal static void UserSentMessage(SocketGuildUser usuario, SocketTextChannel canal)
        {
            var usuarioConta = LevelSystem.Dados.UsuarioDado.GetUsuarioDados(usuario);
            uint oldLevel = usuarioConta.levelNumero;
            usuarioConta.XP += 50;
            LevelSystem.Dados.UsuarioDado.SaveAccounts();
            var novoNivel = usuarioConta.levelNumero;
            if (oldLevel != novoNivel)
            {
                canal.SendMessageAsync($"Parabéns {usuario.Mention} você passou para o nível {novoNivel} e recebeu {usuarioConta.XP} de xp ! :smile:");
            }
        }
    }
}
