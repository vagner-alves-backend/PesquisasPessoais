using Main.Models;

Faculdade faculdade = new();
faculdade.Desserializacao();

Console.Clear();
bool _continue = true;
string? optionInfo = "";
int option = 0;
do
{
    Console.Write(
        "\t---Deseja...\n"+
        "1 °Logar\n"+
        "2 °Cadastrar\n"+
        "3 °Encerrar\n"+
        "--> " 
    );
    optionInfo = Console.ReadLine();
    while (!int.TryParse(optionInfo, out _))
    {
        Console.Write($"O valor [{optionInfo}] é invalido, favor informe um valor valido..: ");
        optionInfo = Console.ReadLine();   
    }
    option = Convert.ToInt32(optionInfo);
    Console.Clear();
    switch (option)
    {
        case 1:
            faculdade.LoginConta();
            break;
        case 2:
            faculdade.Cadastre();
            break;
        case 3: 
            _continue = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("\tInforme uma parametro valido...");
            Console.WriteLine("------------------------------------------");
            break;
    }
} while (_continue);

faculdade.Serializacao();
