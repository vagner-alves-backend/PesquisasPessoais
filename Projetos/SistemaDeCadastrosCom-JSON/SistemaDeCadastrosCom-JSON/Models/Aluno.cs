using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class Aluno(string? name, string? senha)
    {
        private List<Aluno> _alunosRegistros = [];
        public string? Name = name;
        public string? Senha = senha;
        public Aluno() : this ("NaN", "NaN") {}
        public List<Aluno> RegistrosDosAlunos() => _alunosRegistros;
        public void AddAlunoRegistro(Aluno aluno) => _alunosRegistros.Add(aluno);
        public void SetList(string json) => _alunosRegistros = JsonConvert.DeserializeObject<List<Aluno>>(json) ?? [];
    }
}
