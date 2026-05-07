using System.Globalization;

string? operation = "5+3-4+2-1x2";
char parametro = ' ';

int index = 0;
bool isNumber = false;
bool isOperator = false;
bool firstParameter = true;

string? firstNumberText = " ";
string? secondNumberText = " ";
string? previusOperator = " ";

double result = 0;

void Calc ()
{
    if (double.TryParse(firstNumberText, CultureInfo.InvariantCulture, out double firstNumber) && double.TryParse(secondNumberText, CultureInfo.InvariantCulture, out double secondNumber))
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
    parametro = operation[index];
    isNumber = operation[index] switch
    {
        '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => true,
        _ => false
    };
    isOperator = operation[index] switch
    {
        '+' or '-' or 'x' or ':' => true,
        _ => false
    }; 

    if (isNumber)
    {
        if (firstParameter)
        {
            firstNumberText += operation[index].ToString();
        } else
        {
            secondNumberText += operation[index].ToString();
        }
    }

    if (isOperator)
    {
        if (secondNumberText == " ")
        {
            previusOperator = operation[index].ToString();
            firstParameter = false;
        } else
        {
            Calc();
        }
    }

    if ((index+1) >= operation.Length)
    {
        if (previusOperator != " " && secondNumberText != " ")
        {
            Calc();
        }
    }
    index++;
}

Console.WriteLine ($"\t\tResultado: {result}");
