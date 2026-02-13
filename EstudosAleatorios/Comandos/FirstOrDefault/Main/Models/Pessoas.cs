using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Pessoas(string? name, string? senha)
    {
        public string? Name = name;
        public string? Senha = senha;
        public Pessoas() : this ("NaN", "NaN") {}
    }
}
