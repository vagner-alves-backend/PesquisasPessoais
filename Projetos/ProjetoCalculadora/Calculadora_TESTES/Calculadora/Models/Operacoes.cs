using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class Operacoes ()
    {
        protected double Adcao (double first_number, double second_number) => first_number + second_number;     
        protected double Subtracao (double first_number, double second_number) => first_number - second_number;
        protected double Multiplicacao (double first_number, double second_number) => first_number * second_number;
        protected double Divisao (double first_number, double second_number) => first_number / second_number;
    }
}