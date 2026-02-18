using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public static class Login 
    {
        public static bool Login_Aluno(List<Aluno> aluno, string? name, string? password) => aluno.Any(p => p.Name == name && p.Password == password);
    }
}
