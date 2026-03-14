using SistemaDeUmaBiblioteca.Models;
Livro livro = new ();
Console.Clear ();

bool _continue = true;
do
{
    try
    {
        Console.WriteLine ("\t---Teste...");
        Console.Write ("Altor: ");
        livro.NameAltor = Console.ReadLine ();
        Console.Write ("Titulo do livro: ");
        livro.Titulo = Console.ReadLine ();
        Console.Write ("Gênero: ");
        livro.Genero = Console.ReadLine ();
        Console.Write ("Quantas paginas tem o livro? ");
        livro.QantPaginas = Console.ReadLine ();

        _continue = false;
    } catch (Exception ex)
    {
        Console.Clear ();
        Console.WriteLine ($"Ocorreu um erro : {ex.Message}");
        Console.WriteLine ("-----------------------------------------------");
    }
} while (_continue);

Console.WriteLine ("\tSistema finalizado....");
