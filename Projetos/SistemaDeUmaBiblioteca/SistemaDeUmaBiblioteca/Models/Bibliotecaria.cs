using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeUmaBiblioteca.Models
{
    public class Bibliotecaria : Funcionario
    {
        public Bibliotecaria (string? name, string? sobrenome, string? cpf, string? salario) : base (name, sobrenome, cpf, "Bibliotecaria", salario) {}
    }
}