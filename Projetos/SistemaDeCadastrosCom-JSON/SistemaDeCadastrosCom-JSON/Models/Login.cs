using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class Login
    {
        private int _levelLogin;
        public void Logar()
        {
            _levelLogin = Menu.GetLevelLogin();
            switch(_levelLogin)
            {
                case 1:
                    Aluno();
                    break;
                case 2:
                    Professor();
                    break;
            }
        }

        private static void Aluno()
        {
            AlunoCommos.Deserializacao();

            Console.WriteLine("\t--Login Aluno..");
            Console.Write("Name..: ");
            string? name = Console.ReadLine();
            Console.Write("Senha.: ");
            string? senha = Console.ReadLine();

            if (AlunoCommos.Exist(new(name, senha)))
            {
                Console.WriteLine("Registro valido.");
            } else
            {
                Console.Write("Registro invalido, o registro informado não foi encontrado.\nDeseja cadastrar o usuario informado [s/n]: ");
                string? cadastrar = Console.ReadLine();
                if (cadastrar?.ToLower() == "s")
                {
                    AlunoCommos.AddAluno(new(name, senha));
                }
            }
            AlunoCommos.Serializacao();
        }

        private static void Professor()
        {
            ProfessorCommos.Deserializacao();

            Console.WriteLine("\t--Login Professor..");
            Console.Write("Name..: ");
            string? name = Console.ReadLine();
            Console.Write("Senha.: ");
            string? senha = Console.ReadLine();

            if (ProfessorCommos.Exist(new(name, senha)))
            {
                Console.WriteLine("Registro valido.");
            } else
            {
                Console.Write("Registro invalido, o registro informado não foi encontrado.\nDeseja cadastrar o usuario informado [s/n]: ");
                string? cadastrar = Console.ReadLine();
                if (cadastrar?.ToLower() == "s")
                {
                    ProfessorCommos.AddProfessor(new(name, senha));
                }
            }

            ProfessorCommos.Serializacao();
        }
    }
}

