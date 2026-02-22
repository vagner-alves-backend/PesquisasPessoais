using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
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
                        PainelDoDiretor();
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
                Console.WriteLine($"[Erro]: {ex.Message}");
                Console.WriteLine("------------------------------------------");
            }

            Serializacao();
            Desserializacao();
        }
        private void PainelDoAluno()
        {
            Console.Clear();
            string? option = "";
            string? senha = "";

            bool remove = false;

            do{
                Console.Write(
                    "\tPainel do Aluno...\n"+
                    "1 °Ver lista de matérias\n"+
                    "2 °Deslogar da conta\n"+
                    "3 °Cancelar matricula\n"+
                    "--> "
                );
                option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        break;
                    case "2":
                        loginUser.logado = false;
                        break;
                    case "3":
                        Console.Write($"Aluno {_name}, favor informe sua senha: ");
                        senha = Console.ReadLine();
                        if (senha == _password)
                        {
                            remove = Remover(_name, _password, loginUser.nivel);  
                        } else
                        {
                            Console.WriteLine("Senha incorreta, favor tente novamente.");
                        }
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

            string? nameAtual = _name;
            string? passwordAtual = _password;
            string? opcao = "";
            string? senhaAnterior = "";

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
                opcao = Console.ReadLine();
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
                        Console.Write($"Professor {nameAtual}, favor informe sua senha: ");
                        senhaAnterior = Console.ReadLine();
                        if (senhaAnterior == passwordAtual)
                        {
                            remove = Remover(_name, _password, "Professor");
                        } else
                        {
                            Console.WriteLine("Senha incorreta, favor tente novamente.");
                        }
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
        private void PainelDoDiretor()
        {
            Console.Clear();

            string? nameAtual = _name;
            string? passwordAtual = _password;

            string? name = "";
            string? pass = "";
            string? salario = "";
            string? passAnterior = "";
            string? option = "";

            bool remove = false;
            do {
                Console.Write(
                    "\t---Painel do Diretor...\n"+
                    "1 °Cadastrar Professor\n"+
                    "2 °Deletar um professor\n"+
                    "3 °Lista de professores\n"+
                    "4 °Deslogar\n"+
                    "5 °Trocar diretor\n"+
                    "--> "
                );
                option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        RegisterUser("Professor");
                        break;
                    case "2":
                        remove = Remover(_name, _password, "Professor");
                        break;
                    case "3":
                        PrintList("Professor");
                        break;
                    case "4":
                        loginUser.logado = false;
                        break;
                    case "5":
                        Console.WriteLine("\t---Troque o diretor...");
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.Write("Password: ");
                        pass = Console.ReadLine();
                        Console.Write("Salario: ");
                        salario = Console.ReadLine();

                        bool valido = EhPossivelTrocarDiretor(name, pass, "Diretor", salario);
                        if (valido)
                        {
                            Console.Write(
                                "----------------------------------------------------\n"+
                                $"Diretor {nameAtual}, informe sua senha: "
                            );
                            passAnterior = Console.ReadLine();
                            if (passwordAtual == passAnterior)
                            {
                                DiretorAtual(name, pass, "Diretor", salario);
                                loginUser.logado = false;
                                Console.WriteLine("....................................................");
                                Console.WriteLine("O novo diretor foi adicionado..");
                            } else
                            {
                                Console.WriteLine("Senha incorreta, favor tente novamente.");
                            }
                            Console.WriteLine("----------------------------------------------------");
                        }
                        break;
                }
            } while (loginUser.logado);
        }
    }
}
