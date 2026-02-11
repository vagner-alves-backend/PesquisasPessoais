using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class Login : Cadastro
    {
        private string[] _namesReistrados = [];
        private string[] _senhasRegistradas = [];
        private int _loginType = 0;
        private string? _name = "";
        private string? _senha = "";
        private string _caminho = "";
        private string _caminhoSenha = "";

        public void Logar(int login)
        {
            _loginType = login;   
            string? nivelDeLogin = login switch
            {
                1 => "Aluno",
                2 => "Professor",
                3 => "Admin",
                _ => "NaN"
            };
            Console.WriteLine($"---Login do {nivelDeLogin}..");
            Console.Write("Name..: ");
            this._name = Console.ReadLine();
            Console.Write("Senha.: ");
            this._senha = Console.ReadLine();
            Console.WriteLine("---------------------------------");

            bool loginValid = LoginValid();
            if (loginValid)
            {
                Console.WriteLine("Login encontrado...");
            } else
            {
                Console.WriteLine("Login não encontrado, deseja cadastrar o usuario [s/n]: ");
                string? cadastrar = Console.ReadLine();
                if (cadastrar == "s" || cadastrar == "S")
                {
                    File.AppendAllLines(_caminho, [_name ?? "NaN"]);
                    File.AppendAllLines(_caminhoSenha, [_senha ?? "NaN"]);
                } else
                {
                    Console.WriteLine("\t- User não encontrado..");
                }
            }
        }

        private bool LoginValid()
        {
            bool isValid = false;
            PasseList();
            int position = 0;
            foreach (string? nome in _namesReistrados)
            {
                if (nome == this._name)
                {
                    isValid = this._senhasRegistradas[position] == this._senha;
                }
            }
            return isValid;
        }

        private void PasseList()
        {
            FilePath(_loginType);
            _namesReistrados = File.ReadAllLines(_caminho);
            _senhasRegistradas = File.ReadAllLines(_caminhoSenha);
        }

        // private void FilePath(int login)
        // {
        //     _caminho = login switch
        //     {
        //         1 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\alunos.json",
        //         2 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\professores.json",
        //         3 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Registros\\admin.json",
        //         _ => ""
        //     };
        // }

        private void FilePath(int login)
        {
            _caminho = login switch
            {
                1 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Arquivos\\aluno.txt",
                2 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Arquivos\\admin.txt",
                3 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Arquivos\\professor.txt",
                _ => ""
            };

            _caminhoSenha = login switch
            {
                1 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Arquivos\\alunoSenha.txt",
                2 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Arquivos\\adminSenha.txt",
                3 => "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Projetos\\SistemaDeCadastrosCom-JSON\\SistemaDeCadastrosCom-JSON\\Arquivos\\professorSenha.txt",
                _ => ""
            };
        }
        
    }
}
