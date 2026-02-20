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
        private (bool logado, string? nivel) login_user = (logado: false, nivel: "");
        public void LoginUser()
        {
            if (login_user.logado)
            {
                switch (login_user.nivel)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        Student_Panel();
                        break;
                    default:
                        Console.WriteLine("Registro invalido.");
                        login_user.logado = false;
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
            login_user.nivel = Console.ReadLine();

            if (login_user.nivel == "1" || login_user.nivel == "2" || login_user.nivel == "3")
            {
                Console.Clear();
                Console.Write(
                    "---Informe seus dados..\n"+
                    "Name: "
                );
                _name = Console.ReadLine();
                Console.Write("Password: ");
                _password = Console.ReadLine();
            }

            Desserializacao();
            bool login = Login_Valid(login_user.nivel, _name, _password);
            Console.WriteLine(login);
            login_user.logado = login;
            if (login) {LoginUser();}
        }
        public void RegisterUser()
        {
            Console.Clear();
            Console.Write(
                "\t--Login...\n"+
                "1 °Diretor\n"+
                "2 °Professor\n"+
                "3 °Aluno\n"+
                "--> "
            );
            string? optionLog = Console.ReadLine() switch
            {
                "1" => "Diretor",
                "2" => "Professor",
                "3" => "Aluno",
                _ => "NaN"
            };

            Console.Clear();
            if (optionLog != "NaN")
            {
                Console.Write(
                    $"\t---Cadastre {optionLog}...\n"+
                    "Name: "
                );
                _name = Console.ReadLine();
                Console.Write("Password: ");
                _password = Console.ReadLine();
            }

            string? salario = "";
            string? cargo = "";
            string? materia = "";
            string? curso = "";
            try
            {
                switch (optionLog)
                {
                    case "Aluno":
                        Console.Write("Curso: ");
                        curso = Console.ReadLine();

                        AlunoRegister(_name, _password, curso);
                        break;
                    case "Professor":
                        Console.Write("Matéria: ");
                        materia = Console.ReadLine();
                        Console.Write("Salario: ");
                        salario = Console.ReadLine();

                        ProfessorRegister(_name, _password, materia, salario);
                        break;
                    case "Diretor":
                        Console.Write("Cargo: ");
                        cargo = Console.ReadLine();
                        Console.Write("Salario: ");
                        salario = Console.ReadLine();

                        DiretorRegister(_name, _password, salario, cargo);
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada...");
                        break;
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"[Erro]: {ex.Message}");
                Console.WriteLine("------------------------------");
            }

            if (optionLog != "NaN") Serializacao();
        }
        private void Student_Panel()
        {
            Console.Write(
                "\tPainel do Aluno...\n"+
                "1 °Ver lista de matérias\n"+
                "2 °Deslogar da conta\n"+
                "3 °Cancelar matricula\n"+
                "--> "
            );
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    break;
                case "2":
                    login_user.nivel = "";
                    login_user.logado = false;
                    break;
                case "3":
                    Remover(_name, _password, "Aluno");  
                    login_user.logado = false;
                    break;
                default:
                    Console.WriteLine("Opção não encontrada...");
                    break;
            }

            if (!login_user.logado)
            {
                Serializacao();
                Desserializacao(); 
            }
        }
    }
}
