using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public static class AlunoCommos
    {
        private static readonly string _filePath = "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\alunos.json";
        private static bool _registroEncontrado = false;
        private static readonly Aluno _aluno = new();
        public static bool Exist(Aluno aluno)
        {
            _registroEncontrado = false;
            foreach (Aluno registro in _aluno.RegistrosDosAlunos())
            {
                if (registro.Name == aluno.Name && registro.Senha == aluno.Senha)
                {
                    _registroEncontrado = true;
                    break;
                }
            }

            if (!_registroEncontrado)
            {
                foreach (Aluno registro in _aluno.RegistrosDosAlunos())
                {
                    if (registro.Name == aluno.Name)
                    {
                        SenhaIncorreta(aluno.Name);
                        break;
                    }
                }
            }
            return  _registroEncontrado;
        }
        public static void AddAluno(Aluno aluno) => _aluno.AddAlunoRegistro(aluno);
        public static void Serializacao()
        {
            string dados = JsonConvert.SerializeObject(_aluno.RegistrosDosAlunos(), Formatting.Indented);
            File.WriteAllText(_filePath, dados);
        }

        public static void Deserializacao() => _aluno.SetList(File.ReadAllText(_filePath));
        private static void SenhaIncorreta(string? name)
        {
            Console.Write(
                "\t--Senha incorreta..\n"+
                $"-- {name}\n"+
                "Senha..: "
            );
            string? senha = Console.ReadLine();
            Exist(new(name, senha));
        }
    }
}
