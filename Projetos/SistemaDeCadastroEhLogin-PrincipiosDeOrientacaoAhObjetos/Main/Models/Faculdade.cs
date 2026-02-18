using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Faculdade : Login
    {
        private readonly List<Diretora> _diretor = [];
        public List<Professor> _professor = [];
        private readonly List<Aluno> _aluno = [];
        private string? _name;
        private string? _password;
        public void AddAluno()
        {
            Console.Write("Name..: ");
            _name = Console.ReadLine();
            Console.Write("Senha..: ");
            _password = Console.ReadLine();
            Console.Write("Curso..: ");
            string? curso = Console.ReadLine();
            try
            {
                _aluno.Add(new(_name, _password, curso));
                Console.Clear();
            } catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"[Erro]: {ex.Message}");
            }
        }
        public void AddProfessor()
        {
            Console.Write("Name..: ");
            _name = Console.ReadLine();
            Console.Write("Senha.: ");
            _password = Console.ReadLine();
            Console.Write("Matéria..: ");
            string? materia = Console.ReadLine();
            Console.Write("Salario..: ");
            string? salario = Console.ReadLine();

            try
            {
                _professor.Add(new(_name, _password, salario, materia));
                Console.Clear();
            } catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"[Erro]: {ex.Message}");
            }
        }

        public void AddDiretor()
        {
            Console.Write("Name..: ");
            _name = Console.ReadLine();
            Console.Write("Senha.: ");
            _password = Console.ReadLine();
            Console.Write("Salario..: ");
            string? salario = Console.ReadLine();

            try
            {
                _diretor.Add(new(_name, _password, salario));
                Console.Clear();
            } catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"[Erro]: {ex.Message}");
            }
        }

        public void PrintList()
        {
            Console.Clear();
            Console.WriteLine("\t--Professor...");
            foreach (Professor professor in _professor)
            {
                Console.WriteLine(
                    $"Name...: {professor.GetName()}\n"+
                    $"Senha..: {professor.GetPassword()}\n"+
                    $"Matéria: {professor.GetMateria()}\n"+
                    $"Salario: {professor.GetSalario()}\n"+
                    "......................................"
                );
            }
        }

        private bool ValidLogin(string? nivel)
        {

            Console.Write(
                $"---Login ...\n"+
                "Name..: "
            );
            string? name = Console.ReadLine();
            Console.Write("Senha.: ");
            string? password = Console.ReadLine();

            bool valido = nivel switch
            {
                "1" => _diretor.Any(p => p.GetName() == name && p.GetPassword() == password),
                "2" => _professor.Any(p => p.GetName() == name && p.GetPassword() == password),
                "3" => _aluno.Any(p => p.GetName() == name && p.GetPassword() == password),
                _ => false
            };

            Console.WriteLine("========");
            Console.WriteLine(valido);
            Console.WriteLine("========");

            return valido;
        }
        private bool Diretor(string? name, string? password) => _diretor.Any(p => p.GetName() == name && p.GetPassword() == password);
        public bool Professor(string? name, string? password)
        {
            bool valido = _professor.Any(p => p.GetName() == name && p.GetPassword() == password);
            Console.WriteLine(valido);
            return valido;
        }
        private bool Aluno(string? name, string? password) => _aluno.Any(p => p.GetName() == name && p.GetPassword() == password);
        public void Login()
        {
            Logar();
            string? nivel = GetLoginAtual();   
            ValidLogin(nivel);
        }
    }
}
