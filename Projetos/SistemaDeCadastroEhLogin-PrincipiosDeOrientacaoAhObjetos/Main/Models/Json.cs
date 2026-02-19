using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public static class Json
    {
        private static readonly string _pathFileAlunos = "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastroEhLogin-PrincipiosDeOrientacaoAhObjetos\\Main\\Database\\aluno.json";
        private static readonly string _pathFileProfessor = "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastroEhLogin-PrincipiosDeOrientacaoAhObjetos\\Main\\Database\\professor.json";
        private static readonly string _pathFileDiretor = "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastroEhLogin-PrincipiosDeOrientacaoAhObjetos\\Main\\Database\\diretor.json";
        public static void Serializacao(string dados, string level) 
        {
            switch (level)
            {
                case "Aluno": File.WriteAllText(_pathFileAlunos, dados); break;
                case "Professor": File.WriteAllText(_pathFileProfessor, dados); break;
                case "Diretor": File.WriteAllText(_pathFileDiretor, dados); break;
                default:
                    Console.WriteLine("Não foi possivel serializar.");
                    break;
            }       
        }
        public static List<Aluno> Desserializacao_Aluno() {
            string dados = File.ReadAllText(_pathFileAlunos);
            return JsonConvert.DeserializeObject<List<Aluno>>(dados) ?? [];
        }
        public static List<Professor> Desserializacao_Professor() {
            string dados = File.ReadAllText(_pathFileProfessor);
            return JsonConvert.DeserializeObject<List<Professor>>(dados) ?? [];
        }
        public static List<Diretor> Desserializacao_Diretor() {
            string dados = File.ReadAllText(_pathFileDiretor);
            return JsonConvert.DeserializeObject<List<Diretor>>(dados) ?? [];
        }
    }
}