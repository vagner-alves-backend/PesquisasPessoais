using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Aluno : Pessoa
    {
        private string? _cursando;
        public string? Cursando
        {
            get => _cursando;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Curso Null.");
                _cursando = value;
            }
        }

        public Aluno(string? name, string? password, string? cursando) : base ()
        {
            this.Name = name;
            this.Password = password;
            this.Cursando = cursando;
        }
        public string? GetCurso() => _cursando;
    }
}
