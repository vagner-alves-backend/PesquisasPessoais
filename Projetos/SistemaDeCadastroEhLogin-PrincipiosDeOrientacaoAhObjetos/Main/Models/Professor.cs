using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Professor : Funcionario
    {
        private string? _materia;
        public string? Materia
        {
            get => _materia;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Matéria is null.");
                _materia = value;
            }
        }
        public Professor(string? name, string? password, string? salario, string? materia) : base ()
        {
            this.Name = name;
            this.Password = password;
            this.Materia = materia;
            this.Salario = salario;
        }
        public string? GetMateria() => _materia;
    }
}