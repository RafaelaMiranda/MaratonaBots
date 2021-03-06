﻿using Newtonsoft.Json;

namespace LivrariaBrugnars.Models
{
    public class Cotacao
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("sigla")]
        public string Sigla { get; set; }

        [JsonProperty("valor")]
        public float Valor { get; set; }
    }
}