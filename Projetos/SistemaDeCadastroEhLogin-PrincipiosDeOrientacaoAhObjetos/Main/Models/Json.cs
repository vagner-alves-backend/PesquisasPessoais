using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public static class Json
    {
        private static readonly string _pashFileAlunos = "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastroEhLogin-PrincipiosDeOrientacaoAhObjetos\\Main\\Database\\aluno.json";
        public static void Serializacao(string dados, string level) 
        {
            switch (level)
            {
                case "Aluno": File.WriteAllText(_pashFileAlunos, dados); break;
                default:
                    Console.WriteLine("Não foi possivel serializar.");
                    break;
            }       
        }
        public static List<Aluno> Desserializacao_Aluno() {
            string dados = File.ReadAllText(_pashFileAlunos);
            return JsonConvert.DeserializeObject<List<Aluno>>(dados) ?? [];
        }
    }
}