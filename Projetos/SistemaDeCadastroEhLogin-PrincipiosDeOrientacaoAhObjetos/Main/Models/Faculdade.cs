using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Models
{
    public class Faculdade 
    {
        private List<Aluno> _studentList = [];
        private Aluno _aluno = new("Name", "100000", "Matéria");
        public void NewStuden()
        {
            bool registerValid = true;
            do
            {
                try
                {
                    Console.Write(
                        "\t--Register Student...\n"+
                        "Name..: "
                    );
                    _aluno.Name = Console.ReadLine();
                    Console.Write("Password..: ");
                    _aluno.Password = Console.ReadLine();
                    Console.Write("Curso..: ");
                    _aluno.Curso = Console.ReadLine();
                    registerValid = false;
                } catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"[Erro]: {ex.Message}");
                    Console.WriteLine("--------------------------------------------");
                }
            } while (registerValid);

            _studentList.Add(new(_aluno.Name, _aluno.Password, _aluno.Curso));
        }
        public void PrintList(string? level)
        {
            switch (level)
            {
                case "Aluno":
                    foreach (Aluno aluno in _studentList)
                    {
                        Console.WriteLine($"{aluno.Name} - {aluno.Password} - {aluno.Curso}");
                    }
                    break;
                default:
                    Console.WriteLine("Login não encontrado.");
                    break;
            }
        }
        public void Salvar()
        {
            string dados = JsonConvert.SerializeObject(_studentList, Formatting.Indented);
            Json.Serializacao(dados, "Aluno");
        }
        public void Desserializacao() => _studentList = Json.Desserializacao_Aluno();
        public void LoginConta()
        {
            bool valido = true;
            do
            {
                try
                {
                    Console.Write(
                        "\t--Login...\n"+
                        "Name..: "
                    );
                    _aluno.Name = Console.ReadLine();
                    Console.Write("Password..: ");
                    _aluno.Password = Console.ReadLine();
                    valido = false;
                } catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"[Erro]: {ex.Message}");
                    Console.WriteLine("--------------------------------------------");
                }
            } while (valido);
            bool loginValido = Login.Login_Aluno(_studentList, _aluno.Name, _aluno.Password);
            Console.WriteLine($"Esse login é valido..: {loginValido}");
        }
    }
}
