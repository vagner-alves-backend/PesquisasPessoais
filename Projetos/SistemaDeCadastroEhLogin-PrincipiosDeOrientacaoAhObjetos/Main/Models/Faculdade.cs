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
        private readonly Diretor diretorUS = new("name", "102030", "1500", "professor"); 
        private readonly Professor professorUS = new("name", "102030", "matéria", "1500");

        protected void AlunoRegister(string? name, string? pass, string? curso) => professorUS.AddAluno(name, pass, curso);
        protected bool Remover(string? name, string? pass, string? nivel)
        {
            bool remove = nivel switch
            {
                "Professor" => diretorUS.Remover(name, pass),
                "Aluno" => professorUS.Remover(name, pass),
                _ => false
            };
            return remove;
        }
        protected bool LoginValid(string? name, string? pass, string? nivel)
        {
            bool login = nivel switch
            {
                "Aluno" => professorUS.BusqueAluno(name, pass) != null,
                "Professor" => diretorUS.BusqueProfessor(name, pass) != null,
                _ => false
            };

            return login;
        }
        protected void ProfessorRegister(string? name, string? password, string? materia, string? salario) => diretorUS.AddProfessor(name, password, materia, salario);
        protected void PrintList(string? lista)
        {
            switch (lista)
            {
                case "Aluno":
                    professorUS.ListaDeAlunos();
                    break;
                case "Professor":
                    diretorUS.ListaDeProfessores();
                    break;
                default:
                    Console.WriteLine("Lista não encontrada.");
                    break;
            }
        }
        public void Desserializacao()
        {
            diretorUS.Deserializacao_Professor();
            professorUS.Desserialize_Aluno();
        }
        public void Serializacao()
        {
            diretorUS.Serializacao_ProfessorList();
            professorUS.Serializacao_Aluno();
        }
    }
}
