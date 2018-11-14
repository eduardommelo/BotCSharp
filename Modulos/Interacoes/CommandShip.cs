using Discord;
using Discord.Commands;
using Discord.WebSocket;
using NReco.ImageGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{
    public class CommandShip : ModuleBase<SocketCommandContext>
    {
        [Command("ship")]
        public async Task shippar(SocketUser user1, SocketUser user2) {
            EmbedBuilder bd = new EmbedBuilder();
            try
            {

                if (user1.IsBot || user2.IsBot)
                {
                    await ReplyAsync($"Alguém ajuda o(a) {Context.User.Mention}, ele(a) está carente :smile:");
                }
                else
                {

                    Random rdn = new Random();
                    int random = rdn.Next(1, 100);
                    string name1 = Context.Guild.GetUser(user1.Id).Username;
                    string name2 = Context.Guild.GetUser(user2.Id).Username;


                    var avatar1 = Context.Guild.GetUser(user1.Id).GetAvatarUrl();
                    var avatar2 = Context.Guild.GetUser(user2.Id).GetAvatarUrl();
                    string imagem;
                    imagem = "https://i.imgur.com/lHC3i83.png";

                    string mensagens;
                    mensagens = $"{Context.User.Mention}, \n {random}% [█...................] \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) +
                             $" \n Poxa, acho melhor você arrumar outro(a), :smile:";

                    imagem = "https://i.imgur.com/lHC3i83.png"; ;
                    if (random >= 1 && random <= 4)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [█...................] \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) +
                             $"Poxa, acho melhor você arrumar outro(a), :smile:";

                        imagem = "https://i.imgur.com/lHC3i83.png";
                    }
                    if (random > 6 && random <= 10)
                    {

                        mensagens = $"{Context.User.Mention}, \n {random}% [██..................] \n" +
                          $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                          "Que pena parece que ainda não rola um clima entre vocês :broken_heart: ";
                        imagem = "https://i.imgur.com/lHC3i83.png";

                    }
                    if (random > 10 && random <= 15)
                    {

                        mensagens = $"{Context.User.Mention}, \n {random}% [███.................] \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                            "Vai que ela está na sua he he :smile:  ";
                        imagem = "https://i.imgur.com/6zaigBF.png";

                    }
                    if (random >= 16 && random <= 20)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [████................]\n" +
                        $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                        "Pelo jeito isso vai da friendzone :kissing:   ";
                        imagem = "https://i.imgur.com/6zaigBF.png";

                    }
                    if (random > 20 && random <= 25)
                    {

                        mensagens = $"{Context.User.Mention}, \n {random}% [█████...............] \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                            "Esse(a) aí você poderá insistir ainda :smile:   ";
                        imagem = "https://i.imgur.com/6zaigBF.png";

                    }

                    if (random > 26 && random <= 30)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}%  [██████..............] \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                            $"Pelo jeito o  {name2} vai te deixar na friendzone  ";
                        imagem = "https://i.imgur.com/6zaigBF.png";

                    }

                    if (random > 30 && random <= 35)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [███████.............]  \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                            $"Pelo jeito o  {name2} vai te deixar na friendzone  ";
                        imagem = "https://i.imgur.com/6zaigBF.png";

                    }

                    if (random > 36 && random <= 40)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [████████............]\n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                            $"Não desiste  dele(a)! :heart: ";
                        imagem = "https://i.imgur.com/6zaigBF.png";

                    }

                    if (random > 40 && random <= 45)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [█████████...........] \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                            $"Não desiste  dele(a)! :heart: ";
                        imagem = "https://i.imgur.com/6zaigBF.png";

                    }

                    if (random > 46 && random <= 50)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [██████████..........] \n" +
                            $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                            $"Não desiste  dele(a)! :heart: ";
                        imagem = "https://i.imgur.com/gPJrG9l.png";

                    }

                    if (random > 50 && random <= 55)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [███████████.........] \n" +
                          $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                          $"Quem sabe rola algo ai! :smirk: : ";
                        imagem = "https://i.imgur.com/gPJrG9l.png";

                    }

                    if (random > 56 && random <= 60)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [████████████........] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Quem sabe rola algo ai! :smirk:  ";
                        imagem = "https://i.imgur.com/gPJrG9l.png";


                    }

                    if (random > 60 && random <= 65)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [█████████████.......] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Quem sabe rola algo ai! :smirk:  ";
                        imagem = "https://i.imgur.com/gPJrG9l.png";


                    }

                    if (random > 66 && random <= 70)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [██████████████......] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Quem sabe rola algo ai! :smirk:  ";
                        imagem = "https://i.imgur.com/gPJrG9l.png";

                        ;
                    }

                    if (random > 70 && random <= 75)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [███████████████.....] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Quem sabe rola algo ai! :smirk: ";
                        imagem = "https://i.imgur.com/H4Tu71o.png";
                        ;
                    }

                    if (random > 76 && random <= 80)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [████████████████....] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Quem sabe rola algo ai! :smirk: ";
                        imagem = "https://i.imgur.com/H4Tu71o.png";


                    }

                    if (random > 80 && random <= 85)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [█████████████████...] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $" Quem sabe rola algo ai! :smirk: ";
                        imagem = "https://i.imgur.com/H4Tu71o.png";


                    }

                    if (random > 86 && random <= 90)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [██████████████████..]\n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Quem sabe rola algo ai! :smirk: ";
                        imagem = "https://i.imgur.com/H4Tu71o.png";


                    }

                    if (random > 90 && random <= 95)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [███████████████████.] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Quem sabe rola algo ai! :smirk: ";
                        imagem = "https://i.imgur.com/H4Tu71o.png";

                    }

                    if (random > 96 && random <= 100)
                    {
                        mensagens = $"{Context.User.Mention}, \n {random}% [████████████████████] \n" +
                     $"{name1} + {name2} = " + name1.Substring(0, 2) + name2.Substring(name2.Length - 2, 2) + "\n" +
                     $"Vocês dois se combinam ! :heart_eyes:  ";
                        imagem = "https://i.imgur.com/H4Tu71o.png";


                    }










                    string html = "<style>\n    h1{\n     \n        color: Red;\n    }\n    body{\n\n            background: #363942;\n\n    }\n\n    .imgs{\n        width: 123px;\n        height: 123px;\n        float: left;\n        padding: 1px;\n    }\n    body{\n\n        background-image: url('https://i.imgur.com/hnCAoRZ.png');\n    }\n\n</style>\n<body>\n\n    <img class='imgs' src='" + avatar1 + "' />\n<img class='imgs' src='" + imagem + "' />\n    <img  class='imgs' src='" + avatar2 + "' />\n\n\n</body>";

                    var converter = new HtmlToImageConverter
                    {
                        Width = 400,
                        Height = 128
                    };
                    var jpgBytes = converter.GenerateImage(html, NReco.ImageGenerator.ImageFormat.Jpeg);



                    await Context.Channel.SendMessageAsync(mensagens);
                    await Context.Channel.SendFileAsync(new MemoryStream(jpgBytes), "shipp_habbop.jpg");


                }

            }
            catch (Exception ex) {

                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.Red);
                builder.WithDescription($"{Context.User.Mention}. Houve algum erro ao tentar realizar o ship :broken_heart: )");
                await Context.Message.DeleteAsync();
                const int delay = 5000;
                var m = await this.ReplyAsync("", false, builder.Build());
                await Task.Delay(delay);
                await m.DeleteAsync();

            }

        }
      
    }
}
