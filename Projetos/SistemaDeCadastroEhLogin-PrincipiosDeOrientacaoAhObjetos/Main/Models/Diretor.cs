using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Diretor : Funcionario
    {
        private string? _cargo;
        public string? Cargo
        {
            get => _cargo;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favo informe o nivel do cargo da diretoria.");
                _cargo = value;
            }
        }
        
        public Diretor(string? name, string? password, string? salario, string? cargo) : base (name, password, salario) 
        {
            this.Cargo = cargo;
        }
    }
}
