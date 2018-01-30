using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

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

        [LuisIntent("Produto")]
        public async Task Produto(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Está procurando pelo livro {result.Query} estou correto?");
        }

        [LuisIntent("Preco")]
        public async Task Preco(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            await context.PostAsync($"Trabalhamos com as moedas {string.Join(",", moedas.ToArray())}");
        }
    }
}