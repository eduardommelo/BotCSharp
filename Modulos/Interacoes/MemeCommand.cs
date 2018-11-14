using Discord;
using Discord.Commands;
using NReco.ImageGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos.Interacoes
{
   public class MemeCommand : ModuleBase<SocketCommandContext>
    {
        [Command("meme")]
        public async Task memes(string link = "", [Remainder]string legenda = "")
        {
            try
            {

                if (Context.Channel.Id == 469200747184128009)
                {
                    await Context.Message.DeleteAsync();
                    const int delay = 5000;
                    var m = await this.ReplyAsync($"{Context.User.Mention}. Opa, você não pode executar  o comando neste canal, por favor utilize comandos-bot:smile:!");
                    await Task.Delay(delay);
                    await m.DeleteAsync();
                }
                else
                {

                    if (link.Equals("laranja"))
                    {
                        link = "https://i.imgur.com/LXCmEUk.png";
                    }
                    if (link.Equals("jailson"))
                    {
                        link = " https://i.imgur.com/ebbgZ6f.jpg";
                    }
                    string html = "<meta charset='utf-8'>\n<style>\n\n    .img_background{\n        background: url('" + link + "') no-repeat;\n        width: 302px;\n        height: 302px;\n        z-index: 1;\n        \n    }\n\nh1{\n    z-index: 2;\n    color: #fff;\n    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;\n    width: 302px;\n    font-size: 18pt;\n    text-transform: uppercase;\n    text-shadow: 1px 3px 2px #000;\n}\n</style>\n\n<div class='img_background'>\n    <center><h1>" + legenda + "</h1></center>\n</div>";
                    var converter = new HtmlToImageConverter
                    {
                        Width = 298,
                        Height = 298
                    };
                    var jpgBytes = converter.GenerateImage(html, NReco.ImageGenerator.ImageFormat.Jpeg);
                    await Context.Message.DeleteAsync();
                    await ReplyAsync($"{Context.User.Mention}");
                    await Context.Channel.SendFileAsync(new MemoryStream(jpgBytes), "meme_habbop.jpg");
                }
            }catch (Exception ex)
            {
                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync($"{Context.User.Mention}. Opa, ocorreu um erro na hora de executar o comando!:x:!");
                await Task.Delay(delay);
                await m.DeleteAsync();
            }
        }
    }
}
