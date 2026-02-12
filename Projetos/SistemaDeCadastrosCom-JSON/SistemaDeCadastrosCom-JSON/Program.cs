using Newtonsoft.Json;
using SistemaDeCadastrosCom_JSON.Models;
Console.Clear();


Login logar = new();
bool _continue = true;
do
{
    Console.Write(
        "Deseja verificar os registros\n"+
        "[s/n]: "
    );
    string? continuar = Console.ReadLine();
    if (continuar?.ToLower() == "s")
    {
        Console.Clear();
        logar.Logar();
    } else
    {
        _continue = false;
    }
} while (_continue);
