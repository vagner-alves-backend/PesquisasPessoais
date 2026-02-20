using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class Faculdade 
    {
        private List<Aluno> aluno = [];
        private List<Professor> professor = [];
        private List<Diretor> diretor = [];

        protected void AlunoRegister(string? name, string? pass, string? curso) => aluno.Add(new(name, pass, curso));
        protected void Remover(string? name, string? pass, string? nivel)
        {
            switch (nivel)
            {
                case "Aluno":
                    Aluno? alunoAT = aluno.FirstOrDefault(p => p.Name == name && p.Password == pass);
                    if (alunoAT != null)
                    {
                        aluno.Remove(alunoAT);
                        Console.WriteLine("Removido co sucesso.");
                    }
                    break;
                default:
                    Console.WriteLine("Nivel não encontrado.");
                    break;
            }
        }
        protected void ProfessorRegister(string? name, string? password, string? materia, string? salario) => professor.Add(new(name, password, materia, salario));
        protected void DiretorRegister(string? name, string? password, string? salario, string? cargo) => diretor.Add(new(name, password, salario, cargo));
        protected void PrintList(string? nivel)
        {
            Console.WriteLine($"\t---Lista de {nivel}...");
            switch (nivel)
            {
                case "Aluno":
                    foreach (Aluno alunoAT in aluno)
                    {
                        Console.WriteLine($"{alunoAT.Name} - {alunoAT.Password} - {alunoAT.Curso}");
                    }
                    break;
            }
            Console.WriteLine("----------------------------------");
        }
        public bool Login_Valid(string? nivel, string? name, string? pass)
        {
            bool login = nivel switch
            {
                "3" => Login.Login_Aluno(aluno, name, pass),
                "2" => Login.Login_Professor(professor, name, pass),
                "1" => Login.Login_Diretor(diretor, name, pass),
                _ => false
            };
            return login;
        }
        public void Desserializacao()
        {
            diretor = Json.Desserializacao_Diretor() ?? [];
            professor = Json.Desserializacao_Professor() ?? [];
            aluno = Json.Desserializacao_Aluno() ?? [];
        }
        public void Serializacao()
        {
            string? alunoDados = JsonConvert.SerializeObject(aluno, Formatting.Indented);
            Json.Serializacao(alunoDados, "Aluno");

            string? professorDados = JsonConvert.SerializeObject(professor, Formatting.Indented);
            Json.Serializacao(professorDados, "Professor");

            string? diretorDados = JsonConvert.SerializeObject(diretor, Formatting.Indented);
            Json.Serializacao(diretorDados, "Diretor");
        }
    }
}
