using Static.Models;

Console.Clear();
int number = 0;
do
{
    Console.Write("Informe um number: ");
    number = Number.Inteiro(Console.ReadLine());
    Console.Clear();
    Console.WriteLine(
        $"O number informado é {number}\n"+
        "----------------------------------"
    );
} while (number != 404);
