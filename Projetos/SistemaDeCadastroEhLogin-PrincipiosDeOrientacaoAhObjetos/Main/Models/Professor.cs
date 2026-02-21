using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class Professor : Funcionario
    {
        private List<Aluno> _aluno = [];
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

        public void AddAluno(string? name, string? pass, string? curso) => _aluno.Add(new(name, pass, curso));
        public Aluno? BusqueAluno(string? name, string? pass) => _aluno.FirstOrDefault(p => p.Name == name && p.Password == pass);
        public bool Remover(string? name, string? pass)
        {
            bool remove = false;
            Aluno? aluno = BusqueAluno(name, pass);
            if (aluno != null)
            {
                _aluno.Remove(aluno);
                remove = true;
            }
            return remove;
        }
        public void Serializacao_Aluno() => Json.Serializacao(JsonConvert.SerializeObject(_aluno, Formatting.Indented), "Aluno");
        public void Desserialize_Aluno() => _aluno = Json.Desserializacao_Aluno();
        public void ListaDeAlunos()
        {
            Console.WriteLine("\t---Lista de Alunos...");
            foreach (Aluno aluno in _aluno)
            {
                Console.WriteLine(
                    $"Name:     {aluno.Name}\n"+
                    $"Password: {aluno.Password}\n"+
                    $"Curso:    {aluno.Curso}\n"+
                    "....................................."
                );
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
