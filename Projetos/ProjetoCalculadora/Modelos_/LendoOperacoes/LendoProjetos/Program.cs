using System.Globalization;

string? operation = "5+3-4+2-1x2";

int index = 0;
bool isNumber = false;
bool isOperator = false;

string? firstNumberText = "";
string? secondNumberText = "";
string? previusOperator = "";

double result = 0;

void Calc ()
{
    if (double.TryParse(firstNumberText.Trim(), CultureInfo.InvariantCulture, out double firstNumber) && double.TryParse(secondNumberText.Trim(), CultureInfo.InvariantCulture, out double secondNumber))
    {
        result = previusOperator switch
        {
            "+" => firstNumber + secondNumber, 
            "-" => firstNumber - secondNumber,
            "x" => firstNumber * secondNumber,
            ":" => firstNumber / secondNumber,
            _ => 0
        };   
        firstNumberText = Convert.ToString(result);
        secondNumberText = " ";
        previusOperator = operation[index].ToString();
    } else
    {
        Console.WriteLine ("[Erro]: Não foi possível concluir a operação.");
    }
}

while (index < operation.Length)
{
    char current = operation[index];
    isNumber = char.IsDigit(current);
    isOperator = "+-x:".Contains(current);

    if (isNumber)
    {
        if (previusOperator == "")
            firstNumberText += current;
        else
            secondNumberText += current;
    }

    if (isOperator)
    {
        if (secondNumberText != "")
            Calc();

        previusOperator = current.ToString();
    }

    if (index == operation.Length - 1 && secondNumberText != "")
    {
        Calc();
    }

    index++;
}

Console.WriteLine ($"\t\tResultado: {result}");
