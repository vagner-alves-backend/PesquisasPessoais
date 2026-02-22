using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class Faculdade 
    {
        private  Diretor diretorUS = new("Tota", "102030", "3000", "Diretor"); 
        private Diretor diretorAtual = new("Tota", "102030", "3000", "Diretor");
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
                "Diretor" => diretorAtual.Name == name && diretorAtual.Password == pass,
                _ => false
            };

            return login;
        }
        protected void ProfessorRegister(string? name, string? password, string? materia, string? salario) => diretorUS.AddProfessor(name, password, materia, salario);
        protected bool EhPossivelTrocarDiretor(string? name, string? pass, string? cargo, string? salario)
        {
            bool valid = false;
            try
            {
                Diretor diretor = new(name, pass, salario, cargo);
                valid = true;
            } catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Devido a uma inconsistência nos dados, não foi possivel adicionar o novo diretor...");
                Console.WriteLine($"[Erro]: {ex.Message}");
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }

            return valid;
        }
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
            diretorAtual = Json.Desserializacao_Diretor();
        }
        public void DiretorAtual(string? name, string? pass, string? cargo, string? salario)
        {
            Diretor diretor = new(name, pass, salario, "Diretor");
            string? dadosNovoDiretor = JsonConvert.SerializeObject(diretor, Formatting.Indented);
            Json.Serializacao(dadosNovoDiretor, "Diretor");   
            diretorAtual = Json.Desserializacao_Diretor();   
        }
        public void Serializacao()
        {
            diretorUS.Serializacao_ProfessorList();
            professorUS.Serializacao_Aluno();
        }
    }
}
