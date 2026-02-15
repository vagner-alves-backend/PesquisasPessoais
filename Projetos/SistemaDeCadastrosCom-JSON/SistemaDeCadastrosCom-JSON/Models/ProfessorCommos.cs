using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public static class ProfessorCommos
    {
        private static readonly string _filePath = "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\professor.json";
        private static readonly Professor _professor = new();
        private static bool _registroEncontrado = false;
        public static bool Exist(Professor professor)
        {  
            _registroEncontrado = _professor.GetListRegistrosProfessor().Any(p => p.Name == professor.Name && p.Senha == professor.Senha);
            if (!_registroEncontrado)
            {
                _registroEncontrado = _professor.GetListRegistrosProfessor().Any(p => p.Name == professor.Name);
                if (_registroEncontrado) {SenhaIncorreta(professor.Name);}
            }
            return _registroEncontrado;
        } 
        private static void SenhaIncorreta(string? name)
        {
            Console.WriteLine("\t--Senha Incorreta..");
            Console.Write(
                $"- {name}\n"+
                "Senha..: "
            );
            string? senha = Console.ReadLine();
            Exist(new(name, senha));
        }
        public static void AddProfessor(Professor professor) => _professor.AddRegistroProfessor(professor); 
        public static void Serializacao()
        {
            string dados = JsonConvert.SerializeObject(_professor.GetListRegistrosProfessor(), Formatting.Indented);
            File.WriteAllText(_filePath, dados);
        }
        public static void Deserializacao() => _professor.SetList(File.ReadAllText(_filePath));
    }
}