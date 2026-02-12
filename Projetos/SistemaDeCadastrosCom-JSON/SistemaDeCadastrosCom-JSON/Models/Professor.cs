using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class Professor(string? name, string? senha)
    {
        public string? Name = name;
        public string? Senha = senha;
        private List<Professor> _professorRegistros = [];
        public Professor() : this ("NaN", "NaN") {}
        public List<Professor> GetListRegistrosProfessor() => _professorRegistros;
        public void AddRegistroProfessor(Professor professor) => _professorRegistros.Add(professor);
        public void SetList(string json) => _professorRegistros = JsonConvert.DeserializeObject<List<Professor>>(json) ?? [];
    }
}