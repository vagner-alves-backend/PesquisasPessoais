using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Diretor : Funcionario
    {
        private string? _nivel;
        public string? Nivel
        {
            get => _nivel;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favo informe o nivel do cargo da diretoria.");
                _nivel = value;
            }
        }
        
        public Diretor(string? name, string? password, string? salario, string? cargo) : base (name, password, salario) 
        {
            this.Nivel = cargo;
        }
    }
}
