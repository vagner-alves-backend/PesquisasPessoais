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
    public class _Calc
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
    
        private double _resultado = 0;
        public void Calc ()
        {
            Console.Clear ();

            double number_previus = _resultado;
            int ciclo = 0;
            int calc_mod = 0;
            do
            {
                _to_design ();
                try
                {
                    if (ciclo == 0)
                    {
                        Console.Write ("Number: ");
                        number_previus = _resultado;
                        Number = Console.ReadLine ();
                        ciclo = 1;

                        _calcular ();
                    } else
                    {
                        Console.Write ("Operador: ");
                        Operador = Console.ReadLine ();
                        ciclo = 0;
                    }   
                } catch (Exception ex)
                {
                    Console.Clear ();
                    Console.WriteLine ($"\t[ERRO]: {ex.Message}");
                    Console.WriteLine ("---------------------------------------------------");
                }

                Console.Clear ();
                if (calc_mod < 3)
                {
                    calc_mod++;
                } else
                {
                    calc_mod = 2;
                }
                switch (calc_mod)
                {
                    case 1: Console.WriteLine ($"\t{_number} ? 0 = {_number}"); break;
                    case 2: Console.WriteLine ($"\t{_resultado} {_operador} 0 = {_resultado}"); break;
                    case 3: Console.WriteLine ($"\t{number_previus} {_operador} {_number} = {_resultado}"); break;
                    default:
                        Console.WriteLine ($"Calc_mod = {calc_mod}");
                        Console.WriteLine ("\tNão entrou...");
                        break;
                }
                
            } while (_operador != "=");
        }

        private void _calcular ()
        {
            double number = Convert.ToDouble (this._number);
            switch (this._operador)
            {
                case "+": _resultado += number; break;
                case "-": _resultado -= number; break;
                case ":": _resultado /= number; break;
                case "x": _resultado *= number; break;
                default:
                    _resultado += number;
                    break;
            }
        }
        private void _to_design ()
        {            
            Console.WriteLine (
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
