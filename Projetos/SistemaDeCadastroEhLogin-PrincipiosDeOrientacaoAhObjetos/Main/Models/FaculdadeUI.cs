using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class FaculdadeUI : Faculdade
    { 
        private string? _name;
        private string? _password;
        private (bool logado, string? nivel) loginUser = (logado: false, nivel: "");
        public void LoginUser()
        {
            if (loginUser.logado)
            {
                switch (loginUser.nivel)
                {
                    case "Diretor":
                        break;
                    case "Professor":
                        PainelDoProfessor();
                        break;
                    case "Aluno":
                        PainelDoAluno();
                        break;
                    default:
                        Console.WriteLine("Registro invalido.");
                        loginUser.logado = false;
                        break;
                }
                return;
            }

            Console.Write(
                "\t--Login...\n"+
                "1 °Diretor\n"+
                "2 °Professor\n"+
                "3 °Aluno\n"+
                "--> "
            );
            loginUser.nivel = Console.ReadLine() switch
            {
                "1" => "Diretor",
                "2" => "Professor",
                "3" => "Aluno",
                _ => "NaN"
            };

            if (loginUser.nivel != "NaN")
            {
                Console.Clear();
                Console.Write(
                    $"---Informe seus dados do {loginUser.nivel}..\n"+
                    "Name: "
                );
                _name = Console.ReadLine();
                Console.Write("Password: ");
                _password = Console.ReadLine();
            }
            Console.WriteLine("-------------------------------------------");

            bool login = LoginValid(_name, _password, loginUser.nivel);
            loginUser.logado = login;
            if (login) {LoginUser();}
        }
        public void RegisterUser(string? user)
        {
            string? curso = "";
            string? materia = "";
            string? salario = "";

            Console.Clear();
            try {
                switch (user)
                {
                    case "Aluno":
                        Console.Write(
                            "\t---Cadastre Aluno...\n"+
                            "Name: "
                        );
                        _name = Console.ReadLine();
                        Console.Write("Password: ");
                        _password = Console.ReadLine();
                        Console.Write("Curso: ");
                        curso = Console.ReadLine();
                        Console.WriteLine("--------------------------------------");

                        AlunoRegister(_name, _password, curso);
                        break;
                    case "Professor":
                        Console.Write(
                            "\t---Cadastre Professor...\n"+
                            "Name: "
                        );
                        _name = Console.ReadLine();
                        Console.Write("Password: ");
                        _password = Console.ReadLine();
                        Console.Write("Matéria: ");
                        materia = Console.ReadLine();
                        Console.Write("Salario: ");
                        salario = Console.ReadLine();
                        Console.WriteLine("--------------------------------------");

                        ProfessorRegister(_name, _password, materia, salario);
                        break;
                    default: 
                        Console.WriteLine("Tipo de cadastro não encontrado.");
                        break;
                }
            } catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("--Não foi possível cadastrar user..");
                Console.WriteLine($"\t[Erro]: {ex.Message}");
                Console.WriteLine("------------------------------------------");
            }

            Serializacao();
            Desserializacao();
        }
        private void PainelDoAluno()
        {
            Console.Clear();
            bool remove = false;

            do{
                Console.Write(
                    "\tPainel do Aluno...\n"+
                    "1 °Ver lista de matérias\n"+
                    "2 °Deslogar da conta\n"+
                    "3 °Cancelar matricula\n"+
                    "--> "
                );
                string? option = Console.ReadLine();
                Console.WriteLine("--------------------------------------");

                switch (option)
                {
                    case "1":
                        break;
                    case "2":
                        loginUser.logado = false;
                        break;
                    case "3":
                        remove = Remover(_name, _password, loginUser.nivel);  
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada...");
                        break;
                }

                if (remove)
                {
                    loginUser.logado = false;
                    Serializacao();
                    Desserializacao(); 
                }
            } while (loginUser.logado);
        }
        private void PainelDoProfessor()
        {
            Console.Clear();
            bool remove = false;
            do {
                Console.Write(
                    "\t---Painel do Professor...\n"+
                    "--------------------------------------\n"+
                    "1 - Lista de Alunos\n"+
                    "2 - Cadastrar Aluno\n"+
                    "3 - Deslogar\n"+
                    "4 - Deletar Conta\n"+
                    "--> "
                );
                string? opcao = Console.ReadLine();
                Console.WriteLine("--------------------------------------");
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        PrintList("Aluno");
                        break;
                    case "2":
                        RegisterUser("Aluno");
                        break;
                    case "3":
                        loginUser.logado = false;
                        break;
                    case "4":
                        remove = Remover(_name, _password, "Professor");
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada.");
                        break;
                }

                if (remove)
                {
                    loginUser.logado = false;
                    Serializacao();
                    Desserializacao(); 
                }
            } while (loginUser.logado);
        }
    }
}
