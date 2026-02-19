using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public static class Login 
    {
        public static bool Login_Aluno(List<Aluno> aluno, string? name, string? password) => aluno.Any(p => p.Name == name && p.Password == password);
        public static bool Login_Professor(List<Professor> professor, string? name, string? password) => professor.Any(p => p.Name == name && p.Password == password);
        public static bool Login_Diretor(List<Diretor> diretor, string? name, string? password) => diretor.Any(p => p.Name == name && p.Password == password);
    }
}
