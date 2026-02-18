using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Diretora : Funcionario
    {
        public Diretora(string? name, string? password, string? salario) : base ()
        {
            this.Name = name;
            this.Password = password;
            this.Salario = salario;
        }
        public void Demitir(){}
        public void Contratar()
        {
            
        }
        public void Expulsar() {}
        public void Matricular() {}
    }
}