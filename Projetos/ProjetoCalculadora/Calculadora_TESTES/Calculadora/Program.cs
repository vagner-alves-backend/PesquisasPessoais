Console.Clear ();

int option = 0;
string? option_text = "";
bool _continue = true;

do
{
    Console.WriteLine (
        "Qual operação deseja realizar?\n"+
        "\t1 - Adção\n"+
        "\t2 - Subtração\n"+
        "\t3 - Multiplicação\n"+
        "\t4 - Divisão\n\n"
    );

    option_text = Console.ReadLine ();
    Console.Clear ();
    if (int.TryParse (option_text, out option))
    {
        option_text = option switch
        {
            1 => "Adção",
            2 => "Subtração",
            3 => "Multiplicação",
            4 => "Divisão",
            _ => "Opção não emcontrada."
        };
        Console.WriteLine ($"\t{option} - {option_text}");
        _continue = false;
    } else
    {
        Console.WriteLine ("[Erro]: Valor inrregular, favor informe uma das opções presentes abaixo.");
    }
} while (_continue);
