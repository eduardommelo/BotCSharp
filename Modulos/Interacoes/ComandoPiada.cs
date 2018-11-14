using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.Modulos
{
    public class ComandoPiada : ModuleBase<SocketCommandContext>
    {
        [Command("piada")]
        public async Task contaPiada() {

            ulong ids = Context.Channel.Id;
            switch (ids)
            {
                case 469193373647896586: piadas(); break;
                case 469233496485920770:piadas();break;
                default :
                    await Context.Message.DeleteAsync();
                    const int delay = 5000;
                    var m = await this.ReplyAsync($"{Context.User.Mention},:x: Opa! você não pode executar este comando aqui, por favor execute no chat-gerl ou comandos-bot. :smile: ");
                    await Task.Delay(delay);
                    await m.DeleteAsync();break;
            }
          



        }
        public async void piadas()
        {
            Random rdn = new Random();

            int random = rdn.Next(0, 8);
            switch (random)
            {
                case 0:
                    await ReplyAsync("O que tem quatro patas e um braço? \n – Um pit - bull feliz. ?????? ");
                    break;
                case 1:
                    await ReplyAsync("O que um tijolo falou pro outro? \n – Há um ciumento entre nos. ? ");
                    break;
                case 2:
                    await ReplyAsync("O sujeito chegou naquela cidade e ficou sabendo que o José queria vender um burrinho. Achando o bichinho muito simpático, ele perguntou: - Qual é o nome dele? - Num sei, não... - Como não sabe? O bicho não é seu? E o caipira: - Só qui eu num sei qual é o nome dele... eu chamo ele de Zeca, sô.");
                    break;
                case 3:
                    await ReplyAsync("Por que o Manoel ficou duas horas olhando fixamente pra lata de suco de laranja? \n – Porque estava escrito “concentrado”. ?????? ");
                    break;
                case 4:
                    await ReplyAsync("Qual e a parte do corpo da mulher que cheira bacalhau? \n - O nariz. ??? ");
                    break;
                case 5: await ReplyAsync("Sabe por que o italiano não come churrasco? \n– Porque o macarrão não cabe no espeto. ?? "); break;

                case 6:
                    await ReplyAsync("A mãe pergunta ao Joãozinho: “Joãozinho, porque é que já não passas tempo com o teu amigo Marco?”\n" +
                "Joãozinho: “Mãe, tu gostas de passar tempo com alguém que fume, beba e diga palavrões?”\n" +
                "Mãe: “Claro que não, Joãozinho!”\n" +
                "Joãozinho: “Pois, o Marco também não gosta.” ????");
                    break;
                case 7: ReplyAsync("O garoto apanhou da vizinha, e a mãe furiosa foi tomar satisfação: Por que a senhora bateu no meu filho? Ele foi mal-educado, e me chamou de gorda. E a senhora acha que vai emagrecer batendo nele?"); break;

                case 8: ReplyAsync("Um advogado e sua sogra estão em um edifício em chamas. Você só tem tempo pra salvar um dos dois. O que você faz? Você vai almoçar ou vai ao cinema?"); break;

            }
        }

    }
}
