using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class Faculdade 
    {
        private List<Aluno> _studentList = [];
        private List<Professor> _professorList = [];
        private List<Diretor> _diretorList = [];
        private readonly Aluno _aluno = new("Name", "100000", "Matéria");
        private readonly Professor _professor = new("Name", "102030", "Materia", "1500");
        private readonly Diretor _diretor = new("name", "102030", "1500", "Diretor");
        public void Cadastre()
        {
            Console.Clear();
            int option = NivelDeLogin("Cadastro");
            bool logValid = true;
            Console.Clear();

            switch (option)
            {
                case 2:
                    Console.WriteLine(
                        "Para cadastrar um professor é necessario ter o cargo de um diretor...\n"+
                        "---Log com sua conta de diretor.."   
                    );
                    logValid = LoginValid(1);
                    break;
                case 3:
                    Console.Write(
                        "Para cadastrar um aluno se é necessario o cargo de um professor ou de um diretor...\n"+
                        "--Seu cargo é...\n"+
                        "1 °Diretor\n"+
                        "2 °Professor\n"+
                        "--> "
                    );
                    string? cargoInfo = Console.ReadLine();
                    if (cargoInfo == "1" || cargoInfo == "2")
                    {
                        int cargo = Convert.ToInt32(cargoInfo);
                        logValid = LoginValid(cargo);
                    } else
                    {
                        Console.WriteLine("O cargo informado não cumpre os requisitos necessarios...");
                        logValid = false;
                    }
                    break;
                default:
                    Console.WriteLine("Nivel de cadastro indisponivel.");
                    logValid = false;
                    break;
            }

            bool registerValid = true;
            if (logValid)
            {
                do
                {
                    try
                    {
                        switch (option)
                        {
                            case 1:
                                Console.Write(
                                    "\t--Register Diretor...\n"+
                                    "Name..: "
                                );
                                _diretor.Name = Console.ReadLine();
                                Console.Write("Password..: ");
                                _diretor.Password = Console.ReadLine();
                                Console.Write("Cargo..: ");
                                _diretor.Cargo = Console.ReadLine();
                                Console.Write("Salario..: ");
                                _diretor.Salario = Console.ReadLine();

                                _diretorList.Add(new(_diretor.Name, _diretor.Password, _diretor.Salario, _diretor.Cargo));
                                break;
                            case 2:
                                Console.Write(
                                    "\t--Register Professor...\n"+
                                    "Name..: "
                                );
                                _professor.Name = Console.ReadLine();
                                Console.Write("Password..: ");
                                _professor.Password = Console.ReadLine();
                                Console.Write("Materia..: ");
                                _professor.Materia = Console.ReadLine();
                                Console.Write("Salario..: ");
                                _professor.Salario = Console.ReadLine();

                                _professorList.Add(new(_professor.Name, _professor.Password, _professor.Materia, _professor.Salario));
                                break;
                            case 3: 
                                Console.Write(
                                    "\t--Register Aluno...\n"+
                                    "Name..: "
                                );
                                _aluno.Name = Console.ReadLine();
                                Console.Write("Password..: ");
                                _aluno.Password = Console.ReadLine();
                                Console.Write("Curso..: ");
                                _aluno.Curso = Console.ReadLine();

                                _studentList.Add(new(_aluno.Name, _aluno.Password, _aluno.Curso));
                                break;
                            default:
                                Console.WriteLine("Não encotrado.");
                                break;
                        }
                        registerValid = false;
                    } catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine($"[Erro]: {ex.Message}");
                        Console.WriteLine("--------------------------------------------");
                    }
                } while (registerValid);
            } else
            {
                Console.WriteLine("Login não concluido, favor tente novamente...");
            }
        }
        public void PrintList(string? level)
        {
            switch (level)
            {
                case "Aluno":
                    foreach (Aluno aluno in _studentList)
                    {
                        Console.WriteLine($"{aluno.Name} - {aluno.Password} - {aluno.Curso}");
                    }
                    break;
                case "Professor":
                    foreach (Professor professor in _professorList)
                    {
                        Console.WriteLine($"{professor.Name} - {professor.Materia} - {professor.Salario} - {professor.Materia}");
                    }
                    break;
                case "Diretor":
                    foreach (Diretor diretor in _diretorList)
                    {
                        Console.WriteLine($"{diretor.Name} - {diretor.Password} - {diretor.Cargo} - {diretor.Salario}");
                    }
                    break;
                default:
                    Console.WriteLine("Login não encontrado.");
                    break;
            }
        }
        public void LoginConta()
        {
            int nivel = NivelDeLogin("Login");
            bool valido = LoginValid(nivel);

            if (valido)
            {
                Console.WriteLine("\tO login foi concluido com sucesso...");
            }
        }
        private int NivelDeLogin(string? tipo)
        {
            bool logValid = true;
            string? optionInfo = "";
            int option = 0;
            while (logValid)
            {
                Console.Write(
                    $"\t---O nivel de {tipo} é...\n"+
                    "1 °Diretor\n"+
                    "2 °Professor\n"+
                    "3 °Aluno\n"+
                    "--> "
                );
                optionInfo = Console.ReadLine();
                while (!int.TryParse(optionInfo, out _))
                {
                    Console.Write("Favor informe um number inteiro..: ");
                    optionInfo = Console.ReadLine();
                } 
                option = Convert.ToInt32(optionInfo);
                if (option <= 0 || option > 3)
                {
                    Console.WriteLine("Opção não encontrada, favor informe uma opção existente.");
                } else
                {
                    logValid = false;
                }
            }

            return option;
        }
        private bool LoginValid(int nivel)
        {
            bool login = true;
            while (login)
            {
                try
                {
                    Console.Write(
                        "\t---Login...\n"+
                        "Name..: "
                    );
                    _aluno.Name = Console.ReadLine();
                    Console.Write("Password..: ");
                    _aluno.Password = Console.ReadLine();
                    login = false;
                } catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"[Erro]: {ex.Message}");
                    Console.WriteLine("--------------------------------------");
                }
            }
            login = nivel switch
            {
                1 => login = Login.Login_Diretor(_diretorList, _aluno.Name, _aluno.Password),
                2 => login = Login.Login_Professor(_professorList, _aluno.Name, _aluno.Password),
                3 => login = Login.Login_Aluno(_studentList, _aluno.Name, _aluno.Password),
                _ => false
            };

            return login;
        }
        public void Serializacao()
        {
            string? aluno = JsonConvert.SerializeObject(_studentList, Formatting.Indented);
            Json.Serializacao(aluno, "Aluno");

            string? professor = JsonConvert.SerializeObject(_professorList, Formatting.Indented);
            Json.Serializacao(professor, "Professor");

            string? diretor = JsonConvert.SerializeObject(_diretorList, Formatting.Indented);
            Json.Serializacao(diretor, "Diretor");
        }
        public void Desserializacao()
        {
            _studentList = Json.Desserializacao_Aluno();
            _professorList = Json.Desserializacao_Professor();
            _diretorList = Json.Desserializacao_Diretor();
        }
    }
}
