using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class Diretor : Funcionario
    {
        private List<Professor> _professores = [];
        private string? _cargo;
        public string? Cargo
        {
            get => _cargo;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Favo informe o nivel do cargo da diretoria.");
                _cargo = value;
            }
        }
        
        public Diretor(string? name, string? password, string? salario, string? cargo) : base (name, password, salario) 
        {
            this.Cargo = cargo;
        }
        
        public string? GetCargo() => _cargo;
        public void AddProfessor(string? name, string? pass, string? materia, string? salario) => _professores.Add(new(name, pass, materia, salario));
        public Professor? BusqueProfessor(string? name, string? pass) => _professores.FirstOrDefault(p => p.Name == name && p.Password == pass);
        public bool Remover(string? name, string? pass)
        {
            bool remove = false;
            Professor? professor = BusqueProfessor(name, pass);
            if (professor != null)
            {
                _professores.Remove(professor);
                remove = true;
            }
            return remove;
        }
        public void Serializacao_ProfessorList() => Json.Serializacao(JsonConvert.SerializeObject(_professores, Formatting.Indented), "Professor");
        public void Deserializacao_Professor() => _professores = Json.Desserializacao_Professor();
        public void ListaDeProfessores()
        {
            Console.WriteLine("\t---Lista de Professores...");
            foreach (Professor professor in _professores)
            {
                Console.WriteLine(
                    $"Name:     {professor.GetName()}\n"+
                    $"Password: {professor.GetPassword()}\n"+
                    $"Matéria:  {professor.GetMateria()}\n"+
                    $"Salario:  {professor.GetSalario()}\n"+
                    "......................................"
                );
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
