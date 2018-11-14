using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Usuario
{
    public class ServerCommand : ModuleBase<SocketCommandContext>
    {
        [Command("servidor")]
        public async Task sobreServer()
        {
            EmbedBuilder bd = new EmbedBuilder();
            bd.WithTitle($"sobre servidor : {Context.Guild.Name}");
            bd.WithColor(Color.Blue);
            bd.AddInlineField("Membros:", $"```{Context.Guild.Users.Count}```");
            bd.AddInlineField("Status Bot: ", $"```{Context.Client.ConnectionState}```");
            bd.AddInlineField("Habbopianos Online:" ,$"```0```");

            await Context.Message.DeleteAsync();
            await ReplyAsync("", false, bd.Build());
        }
    }
}
