using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Login
    {
        private string? _opcaoLogin;
        private string? _loginAtual;
        private string? OptionLogin
        {
            get => _opcaoLogin;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("the option cannot be null.");
                if (!int.TryParse(value, out _)) throw new Exception("Please provide a number.");
                if (Convert.ToInt32(value) <= 0 || Convert.ToInt32(value) > 3) throw new Exception("option not found.");
                _opcaoLogin = value;
            }
        }
        public void Logar() => _loginAtual = NivelLogin();
        private string? NivelLogin()
        {
            bool valid = true;
            do
            {
                Console.Write(
                    "---Login...\n"+
                    "1 °Diretor\n"+
                    "2 °Professor\n"+
                    "3 °Aluno\n"+
                    "--> "
                );
                try
                {
                    OptionLogin = Console.ReadLine();   
                    valid = false; 
                } catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"[Erro]: {ex.Message}");
                    Console.WriteLine("-----------------------------------");
                }
            } while (valid);

            string? nivel = _opcaoLogin switch
            {
                "1" => "Diretor",
                "2" => "Professor",
                "3" => "Aluno",
                _ => "Desconhecido"
            };
            return nivel;
        }
        public string? GetLoginAtual() => _loginAtual;
    }
}