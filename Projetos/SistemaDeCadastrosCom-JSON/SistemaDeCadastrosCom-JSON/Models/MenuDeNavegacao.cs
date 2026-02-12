using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class MenuDeNavegacao : Login
    {
        private string? _opcaoMenu = "";
        private int _opcaoSelecionada = 0;
        private bool _isValid = true;
        public void MunuInicial()
        {
            Console.Write(
                "---Selecione seu nivel de login..\n"+
                "1 - Aluno\n"+
                "2 - Professor\n"+
                "3 - Administrador\n"+
                "--> "
            );
            do
            {
                _opcaoMenu = Console.ReadLine();
                while (!int.TryParse(_opcaoMenu, out _))
                {
                    Console.WriteLine("[Erro]: Not Number.");
                    Console.Write("Favor informe um number valid..: ");
                    _opcaoMenu = Console.ReadLine();
                }
                _opcaoSelecionada = Convert.ToInt32(_opcaoMenu);
                _isValid = _opcaoSelecionada < 0 || _opcaoSelecionada > 3;
                if (_isValid)
                {
                    Console.WriteLine("[Erro]: Opção não encontrada.");
                    Console.Write("Favor informe um number valid..: ");
                }
            } while (_isValid);
            Logar(_opcaoSelecionada);
        }
    }
}
