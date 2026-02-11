using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class Cadastro(string? name, string? senha)
    {
        private readonly string? _name = name;
        private  readonly string? _senha = senha;
        public Cadastro() : this ("Nome", "Senha"){}

        public string? GetName() => _name;
        public string? GetSenha() => _senha;
    }
}
