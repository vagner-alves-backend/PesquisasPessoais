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
        "1 °Logar\n"+
        "2 °Encerrar\n"+
        "--> "
    );
    option = Console.ReadLine();
    Console.Clear();

    switch (option)
    {
        case "1":faculdade.LoginUser(); break;
        case "2":_continue = false; break;
        default:
            Console.WriteLine("Opção não encontrada.");
            break;
    }
}
