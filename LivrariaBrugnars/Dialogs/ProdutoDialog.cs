using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using AdaptiveCards;
using System.Linq;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace LivrariaBrugnars.Dialogs
{
    [Serializable]
    [LuisModel("1b62a432-1aec-421d-ad87-3207c175928f", "4beff44499c8492a8359493e5b1d8bd9")]

    public class ProdutoDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Desculpe, não consegui entender a frase {result.Query}");
        }

        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu sou um bot e estou sempre aprendendo. Tenha paciência comigo");
        }

        [LuisIntent("Cumprimento")]
        public async Task Cumprimento(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Olá! Eu sou o bot da livraria Brugnars.");
        }

        [LuisIntent("A seleção")]
        public async Task A_Selecao(IDialogContext context, LuisResult result)
        {
            var activity = (Activity)context.Activity;
            var message = activity.CreateReply();

            var heroCard = new HeroCard()
            {
                Title = "A Seleção",
                Subtitle = "Para trinta e cinco meninas, a Seleção é a chance de uma vida inteira. A chance de viver em um palácio e competir pelo coração do lindo Príncipe Maxon. Mas para America Singer, ser selecionado é um pesadelo. Isso significa virar as costas para o amor secreto com Aspen, que é uma casta abaixo dela, e deixando sua casa para entrar em uma competição feroz por uma coroa que ela não quer.",
                Images = new List<CardImage>
                {
                    new CardImage("https://images-na.ssl-images-amazon.com/images/I/51NtuhvaEJL._SX363_BO1,204,203,200_.jpg","Box a seleção")
                },

                Buttons = new List<CardAction>
                {
                    new CardAction(ActionTypes.OpenUrl, "Compre aqui", null, "https://www.amazon.com.br/Selection-5-Book-Box-Set-Complete/dp/0062651633?tag=goog0ef-20&smid=A1ZZFT5FULY4LN&ascsubtag=f15fb8fc-581f-4b8c-a6a2-f69ae703b993")
                }
            };

            message.Attachments.Add(heroCard.ToAttachment());
            await context.PostAsync(message);
        }

        [LuisIntent("Harry Potter")]
        public async Task Harry_Potter(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            await context.PostAsync($"Trabalhamos com as moedas {string.Join(",", moedas.ToArray())}");
        }

        [LuisIntent("Divergente")]
        public async Task Divergente(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            await context.PostAsync($"Trabalhamos com as moedas {string.Join(",", moedas.ToArray())}");
        }

        [LuisIntent("O pequeno principe")]
        public async Task Pequeno_Principe(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            await context.PostAsync($"Trabalhamos com as moedas {string.Join(",", moedas.ToArray())}");
        }

        [LuisIntent("Extraordinário")]
        public async Task Extraordinario(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            await context.PostAsync($"Trabalhamos com as moedas {string.Join(",", moedas.ToArray())}");
        }

        
    }
}