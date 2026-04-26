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
        private string? _first_number;
        public string? First_Number
        {
            get => this._first_number;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe um valor.");
                if (!double.TryParse (value, out double number)) throw new Exception ("Favor informe um valor valido.");
                this._first_number = value;
            }
        }

        private string? _second_number;
        public string? Second_Number
        {
            get => this._second_number;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe um valor.");
                if (!double.TryParse (value, out double number)) throw new Exception ("Favor informe um valor valido.");
                this._second_number = value;
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
            Console.Clear ();
            string? parametro = "0000";
            _to_design (parametro);

            Console.Write ("First Number: ");
            First_Number = Console.ReadLine ();

            Console.Clear ();
            parametro = _first_number;
            _to_design (parametro);

            Console.Write ("Operador: ");
            Operador = Console.ReadLine ();

            Console.Clear ();
            parametro = $"{parametro} {_operador}";
            _to_design (parametro);

            Console.Write ("Second Number: ");
            Second_Number = Console.ReadLine ();

            Console.Clear ();
            parametro = $"{parametro} {Second_Number}";
            _to_design (parametro);
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
