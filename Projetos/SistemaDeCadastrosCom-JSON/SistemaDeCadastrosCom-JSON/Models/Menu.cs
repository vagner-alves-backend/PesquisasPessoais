using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public static class Menu
    {
        private static int _levelLogin = 0;
        private static int MenuInicial()
        {
            bool loginValid = true;
            do
            {
                Console.Write(
                    "\t--Logar como..:\n"+
                    "1- Aluno\n"+
                    "2- Professor\n"+
                    "3- Administrador\n"+
                    "--> "
                );
                string? opcaoMenu = Console.ReadLine();
                Console.WriteLine("...............................");
                while (!int.TryParse(opcaoMenu, out _))
                {
                    Console.Write("Favor informe uma opção valida..: ");
                    opcaoMenu = Console.ReadLine();
                }

                _levelLogin = Convert.ToInt32(opcaoMenu);
                if (_levelLogin < 1 || _levelLogin > 3)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "--Opção não encontrada, favor informe uma opção existente..\n"+
                        "------------------------------------------------------------"
                    );
                } else
                {
                    loginValid = false;
                }
            } while (loginValid);

            return _levelLogin;
        }
        public static int GetLevelLogin() => MenuInicial();
    }
}
