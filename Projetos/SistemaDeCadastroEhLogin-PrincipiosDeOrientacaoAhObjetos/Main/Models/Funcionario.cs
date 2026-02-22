using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Main.Models
{
    public abstract class Funcionario : Pessoa
    {
        private string? _salario;
        public string? Salario
        {
            get => _salario;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favor informe o salario.");
                if (!decimal.TryParse(value, CultureInfo.InvariantCulture, out decimal salario))
                {
                    Console.WriteLine(value);
                    Thread.Sleep(2000);
                    if (!decimal.TryParse(value, out salario)) throw new Exception ("Favor informe valores valido (Salario).");
                }
                if (salario < 1500) throw new Exception ("O valor de salario é inregular, o valor minimo é de [R$ 1.500].");
                _salario = value;
            }
        }
        public Funcionario (string? name, string? password, string? salario) : base (name, password)
        {
            this.Salario = salario;
        }
        public string? GetSalario() => _salario;
    }
}