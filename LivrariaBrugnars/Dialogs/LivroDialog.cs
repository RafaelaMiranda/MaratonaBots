using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Bot.Builder.FormFlow;

namespace LivrariaBrugnars.Dialogs
{
    [Serializable]
    [LuisModel("1b62a432-1aec-421d-ad87-3207c175928f", "4beff44499c8492a8359493e5b1d8bd9")]

    public class LivroDialog : LuisDialog<object>
    {
        private enum TipoDeProcessamento { Emocoes, Descricao, Classificacao }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Desculpe, não consegui entender a frase {result.Query}");
        }

        [LuisIntent("Tudo bem")]
        public async Task TudoBem(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Comigo tudo ótimo :)");
        }

        [LuisIntent("Indicações")]
        public async Task Indicacoes(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Atualmente em nosso estoques temos os livros: O pequeno principe, Harry Potter, Divergente, A Seleção e Extraordinário");
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

            var thumb = new ThumbnailCard()
            {
                Title = "A Seleção",
                Subtitle = "Para trinta e cinco meninas, a Seleção é a chance de uma vida inteira. A chance de viver em um palácio e competir pelo coração do lindo Príncipe Maxon. Mas para America Singer, ser selecionado é um pesadelo. Isso significa virar as costas para o amor secreto com Aspen, que é uma casta abaixo dela, e deixando sua casa para entrar em uma competição feroz por uma coroa que ela não quer.",
                Images = new List<CardImage>
                {
                    new CardImage("https://images-na.ssl-images-amazon.com/images/I/51NtuhvaEJL._SX363_BO1,204,203,200_.jpg","Box A Seleção")
                }
            };

            message.Attachments.Add(thumb.ToAttachment());
            await context.PostAsync(message);
        }

        [LuisIntent("Harry Potter")]
        public async Task Harry_Potter(IDialogContext context, LuisResult result)
        {
            var activity = (Activity)context.Activity;
            var message = activity.CreateReply();

            var thumb = new ThumbnailCard()
            {
                Title = "Harry Potter",
                Subtitle = "A vida do menino Harry Potter não tem um pingo de magia. Ele vive com os tios e o primo, que não gostam nem um pouco dele. O quarto de Harry é, na verdade, um armário sob a escada, e ele nunca comemorou um aniversário sequer em onze anos. Até que, um dia, Harry recebe uma carta misteriosa, entregue por uma coruja: um convite para estudar num lugar incrível chamado Escola de Magia e Bruxaria Hogwarts. Lá ele vai encontrar não só amigos, esportes praticados em vassouras voadoras e magia para todo lado, como também seu destino: ser um aprendiz de feiticeiro até o dia em que terá que enfrentar a pior força do mal, o bruxo que assassinou seus pais. Mas, para isso, Harry precisará passar por uma série de desafios e enfrentar inúmeros perigos.",
                Images = new List<CardImage>
                {
                    new CardImage("https://images.livrariasaraiva.com.br/imagemnet/imagem.aspx/?pro_id=9032983&qld=90&l=430&a=-1","Box Harry Potter")
                }
            };

            message.Attachments.Add(thumb.ToAttachment());
            await context.PostAsync(message);

        }

        [LuisIntent("Divergente")]
        public async Task Divergente(IDialogContext context, LuisResult result)
        {
            var activity = (Activity)context.Activity;
            var message = activity.CreateReply();

            var thumb = new ThumbnailCard()
            {
                Title = "Divergente",
                Subtitle = "Numa Chicago futurista, a sociedade se divide em cinco facções – Abnegação, Amizade, Audácia, Franqueza e Erudição – e não pertencer a nenhuma delas é como ser invisível. Primeiro volume de uma bem-sucedida série de distopia – segmento em alta no mercado editorial juvenil desde o sucesso Jogos Vorazes – Divergente, romance de estreia de Veronica Roth, tem como protagonista uma jovem em embate com suas próprias escolhas. Um dos lançamentos mais aguardados do ano pelos jovens brasileiros, o livro está no topo da lista dos mais vendidos do The New York Times.",
                Images = new List<CardImage>
                {
                    new CardImage("https://images-americanas.b2w.io/produtos/01/00/item/122913/7/122913764_1GG.jpg","Box Divergente")
                }
            };

            message.Attachments.Add(thumb.ToAttachment());
            await context.PostAsync(message);
        }

        [LuisIntent("O pequeno principe")]
        public async Task Pequeno_Principe(IDialogContext context, LuisResult result)
        {
            var activity = (Activity)context.Activity;
            var message = activity.CreateReply();

            var thumb = new ThumbnailCard()
            {
                Title = "O Pequeno Príncipe",
                Subtitle = "Um piloto cai com seu avião no deserto e ali encontra uma criança loura e frágil. Ela diz ter vindo de um pequeno planeta distante. E ali, na convivência com o piloto perdido, os dois repensam os seus valores e encontram o sentido da vida.Com essa história mágica,sensível, comovente, às vezes triste, e só aparentemente infantil, o escritor francês Antoine de Saint - Exupéry criou há 70 anos um dos maiores clássicos da literatura universal.Não há adulto que não se comova ao se lembrar de quando o leu quando criança. Trata - se da maior obra existencialista do século XX, segundo Martin Heidegger.Livro mais traduzido da história, depois do Alcorão e da Bíblia, ele agora chega ao Brasil em nova edição, completa, com a tradução de Frei Betto e enriquecida com um caderno ilustrado sobre a obra e a curta e trágica vida do autor.",
                Images = new List<CardImage>
                {
                    new CardImage("https://images.livrariasaraiva.com.br/imagemnet/imagem.aspx/?pro_id=8501811&qld=90&l=430&a=-1","O pequeno príncipe")
                }
            };

            message.Attachments.Add(thumb.ToAttachment());
            await context.PostAsync(message);
        }

        [LuisIntent("Extraordinário")]
        public async Task Extraordinario(IDialogContext context, LuisResult result)
        {
            var activity = (Activity)context.Activity;
            var message = activity.CreateReply();

            var thumb = new ThumbnailCard()
            {
                Title = "Extraordinário",
                Subtitle = "August Pullman, o Auggie, nasceu com uma síndrome genética cuja sequela é uma severa deformidade facial, que lhe impôs diversas cirurgias e complicações médicas. Por isso, ele nunca havia frequentado uma escola de verdade - até agora. Todo mundo sabe que é difícil ser um aluno novo, mais ainda quando se tem um rosto tão diferente. Prestes a começar o quinto ano em um colégio particular de Nova York, Auggie tem uma missão nada fácil pela frente - convencer os colegas de que, apesar da aparência incomum, ele é um menino igual a todos os outros.",
                Images = new List<CardImage>
                {
                    new CardImage("https://images.livrariasaraiva.com.br/imagemnet/imagem.aspx/?pro_id=4663423&qld=90&l=430&a=-1","Extraordinário")
                }
            };

            message.Attachments.Add(thumb.ToAttachment());
            await context.PostAsync(message);
        }

        [LuisIntent("Cotação")]
        public async Task Cotacao(IDialogContext context, LuisResult result)
        {
            var moedas = result.Entities?.Select(e => e.Entity);
            var filtro = string.Join(",", moedas.ToArray());
            var endpoint = $"http://api-precos20180201084717.azurewebsites.net/api/Cotacoes/{filtro}";

            await context.PostAsync("Aguarde um momento enquanto eu obtenho os valores...");

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Ocorreu algum erro... tente mais tarde");
                    return;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Models.Cotacao[]>(json);
                    var cotacoes = resultado.Select(c => $"R$200 ficará {c.Nome} {200 / c.Valor}");
                    await context.PostAsync($"{string.Join(",", cotacoes.ToArray())}");
                }
            }
        }

        [LuisIntent("Comprar")]
        public async Task Comprar(IDialogContext context, LuisResult result)
        {
            var myform = new FormDialog<Form.Pedido>(new Form.Pedido(), Form.Pedido.BuildForm, FormOptions.PromptInStart, null);
            context.Call(myform, LivroFormComplete);
        }

        private async Task LivroFormComplete(IDialogContext context, IAwaitable<object> result)
        {
            object order = null;
            try
            {
                order = await result;
            }
            catch (OperationCanceledException)
            {
                await context.PostAsync("Você cancelou a compra!");
                return;
            }
            context.Wait(MessageReceived);
        }

        [LuisIntent("Preço")]
        public async Task Preco(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"O preço é R$200,00");
        }

        [LuisIntent("Chegou")]
        public async Task Chegou(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Que legal, espero ter gostado de comprar com a gente. Me envia o link de uma foto sua com o produto para postarmos no site :)");
            context.Wait((c, a) => ProcessarImagemAsync(c, a, TipoDeProcessamento.Emocoes));
        }

        private async Task ProcessarImagemAsync(IDialogContext contexto, IAwaitable<IMessageActivity> argument, TipoDeProcessamento tipoDeProcessamento)
        {
            var activity = await argument;
            Uri uri = null;

            uri = activity.Attachments?.Any() == true ?
                new Uri(activity.Attachments[0].ContentUrl) :
                new Uri(activity.Text);

            try
            {
                string reply;

                switch (tipoDeProcessamento)
                {
                    case TipoDeProcessamento.Emocoes:
                        reply = await new Servicos().DeteccaoDeEmocoesAsync(uri);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(tipoDeProcessamento), tipoDeProcessamento, null);
                }

                await contexto.PostAsync(reply);
            }
            catch (Exception)
            {
                await contexto.PostAsync("Ops! Deu algo errado na hora de analisar sua imagem!");
            }

            contexto.Wait(MessageReceived);
        }
    }
}