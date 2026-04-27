using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Calculadora.Models
{
    public class Design_Calc
    {
        private string? _number;
        public string? Number
        {
            get => this._number;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe um valor.");
                if (!double.TryParse (value, out double number)) throw new Exception ("Favor informe um valor valido.");
                this._number = value;
            }
        }

        private string? _operador;
        public string? Operador
        {
            get => this._operador;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe um operador.");
                bool isValue = value switch
                {
                    "c" or "<-" or "x" or "-" or "+" or ":" or "=" or "+/-" => false,
                    _ => true
                };
                if (isValue) throw new Exception ("Favor informe um operador valido.");

                this._operador = value;
            }
        }
    
        public void Calc ()
        {
            int ciclo = 0;
            do
            {
                if (ciclo == 0)
                {
                    Console.Write ("Number: ");
                    Number = Console.ReadLine ();
                    ciclo = 1;
                } else
                {
                    Console.Write ("Operador: ");
                    Operador = Console.ReadLine ();
                    ciclo = 2;
                }
            } while (_operador != "=");
        }

        private string? _calcular (string? current_number, string? previus_number, string? current_operador)
        {
            return "";
        }
        private void _to_design (string? parametro_info)
        {            
            Console.WriteLine (
                "|\tCalculadora \n"+
                "--------------------------\n"+
                $"| {parametro_info}\n"+
                "--------------------------\n"+
                "|     C     |     <-     |\n"+
                "| 7      8      9   | x  |\n"+
                "| 4      5      6   | -  |\n"+
                "| 1      2      3   | +  |\n"+
                "|+/-     0      ,   | :  |\n"+
                "|           =            |\n"
            );
        }

    }
}
