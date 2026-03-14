using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeUmaBiblioteca.Models
{
    public class Pessoa
    {
        private string? _name;
        public string? Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favor informe o nome...");
                this._name = value;
            }
        }
        private string? _sobrenome;
        public string? Sobrenome
        {
            get => this._sobrenome;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favor informe o sobrenome...");
                this._sobrenome = value;
            }
        }
        private string? _cpf;
        public string? CPF
        {
            get => this._cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favor informe o CPF...");
                if (!long.TryParse(value, out long cpf)) throw new Exception ("Favor informe apenas os algarismos do CPF, sem os caracteres...");
                if (cpf < 10000000000) throw new Exception ("CPF invalido, algarismos insuficientes...");
                if (cpf > 99999999999) throw new Exception ("CPF invalido, algarismos a mais...");
                this._cpf = value;
            }
        }
        public string? GetName () => this._name;
        public string? GetSobrenome () => this._sobrenome;
        public string? GetCPF () => this._cpf;
    }
}