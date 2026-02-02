using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ColocandoArquivosEmPratica.Models
{
    public class Registros
    {
        private readonly string _filePath = "C:\\Users\\Vágner Alves\\OneDrive\\Documentos\\_Meus-Repositorios\\PesquisasPessoais\\Arquivos\\ColocandoArquivosEmPratica\\ColocandoArquivosEmPratica\\Registros\\registros.txt";
        public void AddName(string? name)
        {
            File.AppendAllLines(_filePath, [name ?? "Esta vazio"]); // Essa linha está usando a sintaxi do c#12
        }

        public void PrintListNames()
        {
            Console.WriteLine("Os nomes presentes na lista são..: ");
            string[]? list = File.ReadAllLines(_filePath);
            foreach (string? name in list)
            {
                Console.WriteLine($"\t- {name}");
            }
            Console.WriteLine("-------------------------------------");
        }

        public void RemoveName(string? name)
        { 
            //Essa linha verifica se o caminho do arquivo existe.
            List<string?> listNames = File.Exists(_filePath) ? new(File.ReadAllLines(_filePath)) : [];
            int position = 0;

            position = listNames.IndexOf(name);         
            if (position != -1)
            {
                listNames.Remove(name);
                File.WriteAllText(_filePath, string.Empty);
                
                foreach (string? names in listNames)
                {
                    File.AppendAllLines(_filePath, [names ?? "Está vazio"]);
                }
                Console.WriteLine($"O nome {name}, foi removido.");
            } else
            {
                Console.WriteLine("Name não encontrado.");
            }
        }
    }
}
