using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class Calculadora_Interface : Operacoes
    {
        private void Design_Calc ()
        {
            Console.WriteLine (
                "\t\t|       TELA|\n"+
                "\t\t.-----------.\n"+
                "\t\tCE  C   /  <-\n"+
                "\t\t7   8   9   x\n"+
                "\t\t4   5   6   -\n"+
                "\t\t1   2   3   +\n"+
                "\t\t+/- 0   ,   =\n"+
                "\t\t.-----------.\n\n"
            );
        }

        public void Calc ()
        {
            bool valid = false;
            bool selected_operation = false;

            double first_number = 0;
            double second_number = 0;
            double result = 0;

            string? number_text = "";
            string? operation = "";

            Design_Calc ();
            Console.Write ("First Number: ");
            number_text = Console.ReadLine ();

            valid = double.TryParse (number_text, out first_number);
            while (!valid)
            {
                Console.WriteLine ($"\t[Erro]: Favor informe um valor valido.");
                Console.Write ("-> ");
                number_text = Console.ReadLine ();
                valid = double.TryParse (number_text, out first_number);
            }

            Console.Write ("Second Number: ");
            number_text = Console.ReadLine ();

            valid = double.TryParse (number_text, out second_number);
            while (!valid)
            {
                Console.WriteLine ($"\t[Erro]: Favor informe um valor valido.");
                Console.Write ("-> ");
                number_text = Console.ReadLine ();
                valid = double.TryParse (number_text, out second_number);
            }

            Console.WriteLine (
                "\t-Deseja realizar qual operação?\n"+
                "1 - Adção\n"+
                "2 - Subtração\n"+
                "3 - Multiplicação\n"+
                "4 - Divisão\n\n"
            );
            operation = Console.ReadLine ();

            selected_operation = operation switch
            {
                "1" or "2" or "3" or "4" => true,
                _ => false
            };

            while (!selected_operation)
            {
                Console.WriteLine ("\tFavor informe uma das opções existentes.");
                Console.Write ("->");
                operation = Console.ReadLine ();
                selected_operation = operation switch
                {
                    "1" or "2" or "3" or "4" => true,
                    _ => false
                };
            }

            operation = operation switch
            {
                "1" => "Adção",
                "2" => "Subtração",
                "3" => "Multiplicação",
                "4" => "Divisão",
                _ => "NaN"
            }; 

            result = operation switch
            {
                "Adção" => Adcao (first_number, second_number),
                "Subtração" => Subtracao (first_number, second_number),
                "Multiplicação" => Multiplicacao (first_number, second_number),
                "Divisão" => Divisao (first_number, second_number),
                _ => 0
            };

            Console.WriteLine ($"\t\tResultado: {result}");
        }
    }
}