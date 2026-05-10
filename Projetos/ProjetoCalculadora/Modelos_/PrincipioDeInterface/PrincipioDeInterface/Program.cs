using System.Globalization;
using System.Linq.Expressions;
using PrincipioDeInterface.Models.Interface;
using PrincipioDeInterface.Models.Services;

Console.Clear();
var operation = new Dictionary <string, IOperation>
{
    {"+", new Addition()},
    {"-", new Subtraction()},
    {"x", new Multiplication()},
    {":", new Division()}
};

double Calc (string symbolCurrent, string firstNumberText, string secondNumberText)
{
    double result = 0;
    if (operation.TryGetValue(symbolCurrent, out IOperation? calculation))
    {
        if (double.TryParse(firstNumberText, NumberStyles.Any, CultureInfo.InvariantCulture, out double firstNumber) && double.TryParse(secondNumberText, NumberStyles.Any, CultureInfo.InvariantCulture, out double secondNumber))
        {
            result = calculation.Execulte(firstNumber, secondNumber);
        }
    }

    return result;
}

static bool ValidateOperation (string op)
{
    bool valid = true;
    for (int i = 0; i < op.Length; i++)
    {
        if (!char.IsDigit(op[i]) && !"+-x:".Contains(op[i]))
            valid = false;
    }
    return valid;
}

bool valid = false;
string? operacao = "";
do
{
    Console.Write("Operação: ");
    operacao = Console.ReadLine();

    if (operacao == null) return;
    valid = ValidateOperation(operacao);

    if (!valid) 
        Console.WriteLine("Favor informe uma operação valida.");
} while (!valid);

string firstNumberText = "";
string secondNumberText = "";
string symbol = "";

double result = 0;
for (int i = 0; i < operacao.Length; i++)
{
    if ("+-x:".Contains(operacao[i])) 
    {
        if (symbol != "")
        {
            if (secondNumberText != "") 
            {
                result = Calc (symbol, firstNumberText, secondNumberText);
                firstNumberText = result.ToString();
                secondNumberText = "";
            }
        }
        symbol = operacao[i].ToString();
    } else 
    {
        if (symbol == "")
            firstNumberText += operacao[i];
        else 
            secondNumberText += operacao[i];
    }  
}

if (secondNumberText != "")
    result = Calc(symbol, firstNumberText, secondNumberText);

Console.WriteLine($"\t\tResultado: {result}");
