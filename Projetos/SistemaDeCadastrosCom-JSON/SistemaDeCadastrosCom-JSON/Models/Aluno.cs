using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    [JsonObject]
    public class Aluno(string? name, string? senha)
    {
        [JsonProperty("Name")]
        private readonly string? _name = name;
        [JsonProperty("Senha")]
        private readonly string? _senha = senha;
        public Aluno() : this("NaN", "NaN") {}

        public string? GetName() => _name;
        public string? GetSenha() => _senha;
    }
}
