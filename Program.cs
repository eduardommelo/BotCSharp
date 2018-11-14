using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Habbop.LevelSystem.Dados;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Habbop
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();



        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;



        public async Task RunBotAsync()
        {



            // Iniciando o bot
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|Bot iniciado com sucesso");
                    Console.WriteLine("\n\n");
                    Console.ForegroundColor = ConsoleColor.Green;

                    _client = new DiscordSocketClient();
                    _commands = new CommandService();
                    _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();

                    // Token do Bot
                    string botToken = "Token do seu bot";


                // assinatura de evento 
                _client.Ready += Client_Ready;
                _client.Log += Log;
              //  _client.ReactionAdded += _client_reactionAdded;
                 _client.UserJoined += AnnounceUserJoined;


                await Client_Ready();
                await ComandosBot();

                _client.LoginAsync(TokenType.Bot, botToken);
        

                    await _client.StartAsync();
               
  

                    await Task.Delay(-1);
                

            
           
            }

        private async Task _client_reactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == Global.MenssagemToTrack)
            {
                if (reaction.Emote.Name == "👌")
                {
                    await channel.SendMessageAsync($"{reaction.User.Value.Username} reagiu bem :smile: ");
                }
      
            }
            
        }

        private  async Task AnnounceUserJoined(SocketGuildUser user)
        {
            var guild = user.Guild;
            var channel = guild.GetTextChannel(419158949414305802);
            var usuarios = user.Guild.GetUser(user.Id);
        /*   await usuarios.SendMessageAsync($"Bem vindo ao {user.Guild.Name} Nunca foi tão divertido está nesta família, ajude a nós se tornar melhor divulgando o nosso link e o nosso discord \n ***Servidor*** : http://habbop.com.br/  \n ***Discord*** : https://discord.gg/AZuvBzq \n E mais uma coisa! curta a nossa página :smile: \n" +
                                    "https://www.facebook.com/HabbopOfficial/ \n\n https://cdn.discordapp.com/attachments/456641846869884929/477285929615360010/bb.png");*/

            // dar cargo de membros
            
           // var role = user.Guild.Roles.FirstOrDefault(x => x.Name == "👥 Membros");
           // await usuarios.AddRoleAsync(role);
           // await channel.SendMessageAsync($":heart:  Bem vindo  " + user.Mention + $" tenha uma ótima estadia, qualquer coisa estou aqui viu?! sór pedir por ,ajuda / :ajuda :smile:.");
            
        }

        private Task Log(LogMessage arg)
            {
                Console.WriteLine(arg);
                return Task.CompletedTask;
            }


        private async Task Client_Ready()

        {


   
           
            await _client.SetGameAsync($"Activity do bot ", "http://habbop.com.br", StreamType.NotStreaming);
           

        }

        public async Task ComandosBot()
            {
                _client.MessageReceived += HandleCommandAsync;
                await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

            }

      

        private async Task HandleCommandAsync(SocketMessage arg)
            {

                var mensagem = arg as SocketUserMessage;
                 if (mensagem is null || mensagem.Author.IsBot) return;
                 var context = new SocketCommandContext(_client, mensagem);
                 

                     int argPost = 0;
                //Upando de nível 
                Level.UserSentMessage((SocketGuildUser)context.User, (SocketTextChannel)context.Channel);
            // sintaxe do comando
                if(mensagem.HasMentionPrefix(_client.CurrentUser, ref argPost))
                {
                    await arg.Channel.SendMessageAsync($"{arg.Author.Mention} Olá, para saber o que eu posso fazer por você digite ,ajuda / :ajuda :smile: em breve irei conversar com vocês. :smile:");

                }
                if (mensagem.HasStringPrefix(",", ref argPost) || mensagem.HasStringPrefix(":", ref argPost))
                {

                    var result = await _commands.ExecuteAsync(context, argPost);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);

                }
          
                }

         
            }

      

    }
}
