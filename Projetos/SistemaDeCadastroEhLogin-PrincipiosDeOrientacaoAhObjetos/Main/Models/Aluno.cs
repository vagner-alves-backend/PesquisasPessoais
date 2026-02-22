using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class Aluno : Pessoa
    {
        private string? _curso;
        public string? Curso
        {
            get => _curso;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Value is null.");
                _curso = value;
            }
        }

        //[System.Text.Json.Serialization.JsonConstructor]
        public Aluno(string? name, string? password, string? curso) : base(name, password)
        {
            this.Curso = curso;
        }
        public string? GetCurso() => _curso;
    }
}
