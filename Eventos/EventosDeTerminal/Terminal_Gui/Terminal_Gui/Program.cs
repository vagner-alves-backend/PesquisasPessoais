using System.Collections;
using System.Collections.Frozen;
using System.IO.Pipelines;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Terminal.Gui;

Application.Init ();

var win = new Window () 
{
    Title = "Terminal", X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill()
};

var tela = new Label (" ")
{
    X = Pos.Center(),
    Y = 2,
    Width = 40,
    ColorScheme = Colors.Dialog
};

int resultado = 0;
string? Perform_Operation (string? current_value, string? previus_value, string? operation)
{
    int.TryParse (current_value, out int current_number);
    int.TryParse(previus_value, out int previus_number);
    resultado = operation switch
    {
        "+" => previus_number + current_number,
        "-" => previus_number - current_number,
        "x" => previus_number * current_number,
        ":" => previus_number / current_number,
        "=" => resultado,
        _ => 0
    };

    return Convert.ToString (resultado);
}

string? firstNumber = " ";
string? secondNumber = " ";
string? seletedOperator = " ";
void Order_Of_Operation (string? parametro)
{
    bool isOperator = parametro switch
    {
        "+" or "-" or "x" or ":" => true,
        _ => false  
    };

    bool isClear = parametro switch
    {
        "<" or "c" => true,
        _ => false
    };

    if (isOperator && firstNumber != " ")
    {
        if (seletedOperator == " ")
        {
            seletedOperator = parametro;
            tela.Text = tela.Text.ToString() + parametro;
        } else if (secondNumber != " ")
        {
            string? resultado = Perform_Operation (secondNumber, firstNumber, seletedOperator);
            tela.Text = resultado + parametro;
            seletedOperator = parametro;
        } else
        {
            tela.Text = tela.Text.Substring(0, tela.Text.Length - 1) + parametro;
            seletedOperator = parametro;
        }
    } else if (isClear)
    {
        if (parametro == "<")
        {
            int index = tela.Text.Length;
            isOperator = tela.Text[index -1].ToString() switch
            {
                "+" or "-" or "x" or ":" => true,
                _ => false  
            };

            if (isOperator)
            {
                seletedOperator = " ";
                secondNumber = " ";
            }
            tela.Text = tela.Text.Substring(0, tela.Text.Length -1);
        } else
        {
            firstNumber = " ";
            secondNumber = " ";
            seletedOperator = " ";
            tela.Text = " ";
        }
    } else
    {
        if (seletedOperator == " ")
        {
            firstNumber += parametro;
        } else
        {
            secondNumber += parametro;
        }
        tela.Text = tela.Text.ToString() + parametro;
    }
}

void Form_the_operation (string? parametro)
{
    if (parametro == "=")
    {
        if (firstNumber != " " && secondNumber != " ")
        {
            string? resultado = Perform_Operation (secondNumber, firstNumber, seletedOperator);
            tela.Text = resultado;
        } else if (secondNumber == " ")
        {
            tela.Text = firstNumber;
        } else
        {
            tela.Text = "0";
        }
    } else
    {
        Order_Of_Operation (parametro);
    }
}

var btn1 = new Button (" 1 ") {X = Pos.Center() - 12, Y = 6};
var btn2 = new Button (" 2 ") {X = Pos.Center(), Y = 6};
var btn3 = new Button (" 3 ") {X = Pos.Center() + 6, Y = 6};
win.Add (btn1, btn2, btn3);

var btn4 = new Button (" 4 ") {X = Pos.Center() - 12, Y = 7};
var btn5 = new Button (" 5 ") {X = Pos.Center(), Y = 7};
var btn6 = new Button (" 6 ") {X = Pos.Center() + 6, Y = 7};
win.Add (btn4, btn5, btn6);

var btn7 = new Button (" 7 ") {X = Pos.Center() - 12, Y = 8};
var btn8 = new Button (" 8 ") {X = Pos.Center(), Y = 8};
var btn9 = new Button (" 9 ") {X = Pos.Center() + 6, Y = 8};
win.Add (btn7, btn8, btn9);

var btnAdicao = new Button (" + ") {X = Pos.Center() - 12, Y = 5};
var btnSubtracao = new Button (" - ") {X = Pos.Center(), Y = 5};
var btnMultiplicacao = new Button (" x ") {X = Pos.Center() + 6, Y = 5};
var btnClear = new Button (" C ") {X = Pos.Center() - 21, Y = 5};
win.Add (btnAdicao, btnSubtracao, btnMultiplicacao, btnClear);

var btnDelete = new Button (" < ") {X = Pos.Center() - 21, Y = 6};
var btnDivisao = new Button (" : ") {X = Pos.Center() - 21, Y = 7};
win.Add (btnDelete, btnDivisao);

var btn0 = new Button (" 0 ") {X = Pos.Center(), Y = 9};
var btnIgual = new Button (" = ") {X = Pos.Center() - 21, Y = 8};
win.Add (btn0, btnIgual);

btn1.Clicked += () => Form_the_operation ("1");
btn2.Clicked += () => Form_the_operation ("2");
btn3.Clicked += () => Form_the_operation ("3");

btn4.Clicked += () => Form_the_operation ("4");
btn5.Clicked += () => Form_the_operation ("5");
btn6.Clicked += () => Form_the_operation ("6");

btn7.Clicked += () => Form_the_operation ("7");
btn8.Clicked += () => Form_the_operation ("8");
btn9.Clicked += () => Form_the_operation ("9");

btn0.Clicked += () => Form_the_operation ("0");

btnAdicao.Clicked += () => Form_the_operation ("+");
btnSubtracao.Clicked += () => Form_the_operation ("-");
btnMultiplicacao.Clicked += () => Form_the_operation ("x");
btnDivisao.Clicked += () => Form_the_operation (":");

btnIgual.Clicked += () => Form_the_operation ("=");
btnDelete.Clicked += () => Form_the_operation ("<");
btnClear.Clicked += () => Form_the_operation ("c");

win.Add (tela);
Application.Top.Add (win);
Application.Run ();

Application.Shutdown ();
