using PrincipioDeInterface.Models.Interface;
using PrincipioDeInterface.Models.Services;

var operacoes = new Dictionary <string, IOperation>
{
    {"+", new Addition()},
    {"-", new Subtraction()},
    {"x", new Multiplication()},
    {":", new Division()}
};

string firstNumber = "5";
string secondNumber = "3";
string symbol = "+";

if (operacoes.TryGetValue(symbol, out IOperation? operacao))
{
    double result = operacao.Execulte (double.Parse(firstNumber), double.Parse(secondNumber));
    Console.WriteLine ($"\tResultado: {result}");
}

