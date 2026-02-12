using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Runtime;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class Login
    {
        private string _filePath = "";
        public string? Name = "";
        public string? Senha = "";

        public void Logar(int login)
        {
            FilePath(login);
            switch (login)
            {
                case 1:
                    Aluno();
                    break;
                case 2:
                    Professor();
                    break;
                case 3:
                    Admin();
                    break;
                default:
                    Console.WriteLine("Nivel de acesso não encontrado.");
                    break;
            }
        }

        private void Aluno()
        {
            bool _continue = true;
            ListaDados<Aluno> aluno = new();
            if (File.Exists(_filePath))
            {
                string jsonSalvo = File.ReadAllText(_filePath);
                aluno = JsonConvert.DeserializeObject<ListaDados<Aluno>>(jsonSalvo) ?? new();   
            }
            do
            {                
                Console.WriteLine("--Login Aluno..");
                Console.Write("Name..: ");
                Name = Console.ReadLine();
                Console.Write("Senha.: ");
                Senha = Console.ReadLine();

                bool encontrado = false;
                if (aluno.ContemElementos)
                {
                    foreach (Aluno registros in aluno)
                    {
                        if (registros.GetName() == Name && registros.GetSenha() == Senha)
                        {
                            Console.WriteLine("Registro encontrado.");
                            encontrado = true;
                        }
                    }   
                } 

                if (!encontrado) {
                    Console.WriteLine("--Deseja cadastrar o aluno [s/n]: ");
                    string? cadastreAluno = Console.ReadLine();
                    if (cadastreAluno?.ToLower() == "s")
                    {
                        aluno.AddRegistro(new Aluno(Name, Senha));
                        string serializacao = JsonConvert.SerializeObject(aluno);
                        File.WriteAllText(_filePath, serializacao);
                    }
                    _continue = false;
                }
            } while(_continue);
        }

        private void Professor()
        {
            ListaDados<Professor> professor = new();
        }

        private void Admin()
        {
            ListaDados<Admin> admin = new();
        }

        private void FilePath(int login)
        {
            _filePath = login switch
            {
                1 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\alunos.json",
                2 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\professores.json",
                3 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\admin.json",
                _ => ""
            };
        }        
    }
}
