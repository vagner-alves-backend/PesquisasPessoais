using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Funcionario : Pessoa
    {
        private string? _salario;
        public string? Salario
        {
            get => _salario;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Salario is Null.");
                if (!decimal.TryParse(value, out _))
                {
                    throw new ArgumentException("O valor do salário deve ser um número decimal válido.", nameof(Salario));
                } 
                _salario = value;
            }
        }
        public string? GetSalario() => _salario;
    }
}
