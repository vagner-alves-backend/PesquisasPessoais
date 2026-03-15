using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeUmaBiblioteca.Models
{
    public abstract class Funcionario : Pessoa
    {
        private string? _cargo;
        public string? Cargo
        {
            get => this._cargo;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe ocargo do funcionario...");
                this._cargo = value;
            }
        }
        private string? _salario;
        public string? Salario
        {
            get => this._salario;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe o salario do funcionario...");
                if (!double.TryParse (value, out double salario)) throw new Exception ("Salario invalido, favor informe um valor valido...");
                if (salario < 1500) throw new Exception ("O salario não cumpre o valor minimo permitido pela lei...");
                this._salario = value;
            }
        }
        
        public Funcionario (string? name, string? sobrenome, string? cpf, string? cargo, string? salario) : base (name, sobrenome, cpf)
        {
            Cargo = cargo;
            Salario = salario;
        }

        public string? GetCargo () => this._cargo;
        public string? GetSalario () => this._salario;
    }
}