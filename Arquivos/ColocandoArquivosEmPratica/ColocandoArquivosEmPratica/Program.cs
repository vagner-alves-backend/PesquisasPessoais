using System.IO;
using System.Linq.Expressions;
using ColocandoArquivosEmPratica.Models;

Registros registro = new();
bool _continue = true;
string? option = "";
string? newName = "";

Console.Clear();
do
{
    Console.Write(
        "---Deseja..: \n"+
        "1-Adicionar\n"+
        "2-Remover\n"+
        "3-Imprimir\n"+
        "4-Finalizar..: "
    );
    option = Console.ReadLine();
    Console.Clear();
    switch (option)
    {
        case "1":
            Console.Write("Name..: ");
            newName = Console.ReadLine();
            registro.AddName(newName);
            Console.WriteLine($"O nome {newName}, foi adicionar.");
            Console.WriteLine("--------------------------------------");
            break;
        case "2":
            Console.Write("Name..: ");
            newName = Console.ReadLine();
            registro.RemoveName(newName);
            Console.WriteLine("--------------------------------------");
            break;
        case "3":
            registro.PrintListNames();
            break;
        case "4":
            _continue = false;
            break;
        default:
            Console.WriteLine("[Erro]: Opção não encontrada.");
            break;
    }
} while (_continue);

