using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Faculdade
    {
        private readonly List<Aluno> _aluno = [];
        private readonly List<Professor> _professor = [];
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
    }
}
