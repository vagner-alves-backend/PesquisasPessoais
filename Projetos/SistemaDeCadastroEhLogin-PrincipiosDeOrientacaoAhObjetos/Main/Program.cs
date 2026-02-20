using Main.Models;

FaculdadeUI faculdade = new();
Console.Clear();
faculdade.Desserializacao();

bool _continue = true;
string? option = "";
while (_continue)
{
    Console.Write(
        "\t---Deseja...\n"+
        "1 °Login\n"+
        "2 °Cadastrar\n"+
        "3 °Encerrar\n"+
        "--> "
    );
    option = Console.ReadLine();
    Console.Clear();

    switch (option)
    {
        case "1":
            faculdade.LoginUser();
            break;
        case "2":
            faculdade.RegisterUser();
            break;
        case "3":
            _continue = false;
            break;
        default:
            Console.WriteLine("Opção não encontrada.");
            break;
    }
}
