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
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favor informe a matéria.");
                _materia = value;
            }
        }
        public Professor(string? name, string? password, string? materia, string? salario) : base (name, password, salario)
        {
            this.Materia = materia;
        }
    }
}
