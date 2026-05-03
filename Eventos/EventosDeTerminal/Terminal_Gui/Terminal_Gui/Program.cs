using System.Collections;
using System.Reflection.Metadata;
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
        "=" => resultado,
        _ => 0
    };

    return Convert.ToString (resultado);
}

string? selected_operator = "NaN";
string? previus_number_text = "NaN";
bool previus_result = false;
void Form_the_operation (string? parametro)
{
    bool operation = parametro switch
    {
        "+" or "-" or "x" or "=" => true,
        _ => false
    };

    if (operation && parametro != "=")
    {
        if (selected_operator == "NaN")
        {
            previus_number_text = tela.Text.ToString();
            selected_operator = parametro;
            tela.Text = tela.Text.ToString() + parametro;
        } else
        {
            selected_operator = parametro;
            tela.Text = tela.Text.Substring (0, tela.Text.Length - 2) + parametro;
        }
    } else
    {
        if (previus_number_text != "NaN")
        {
            parametro = Perform_Operation (parametro, previus_number_text, selected_operator);
            previus_number_text = "NaN";
            selected_operator = "NaN";
            tela.Text = parametro;
        } else if (parametro != "=")
        {
            if (previus_result)
            {
                tela.Text = parametro;
                previus_result = false;
            } else
            {
                tela.Text = tela.Text.ToString() + parametro;    
            }
        } else
        {
            tela.Text = $"= {resultado}";
            previus_result = true;
        }
    }
}

var btn1 = new Button (" 1 ") {X = Pos.Center() - 12, Y = 6};
var btn2 = new Button (" 2 ") {X = Pos.Center(), Y = 6};
var btn3 = new Button (" 3 ") {X = Pos.Center() + 6, Y = 6};

var btn4 = new Button (" 4 ") {X = Pos.Center() - 12, Y = 7};
var btn5 = new Button (" 5 ") {X = Pos.Center(), Y = 7};
var btn6 = new Button (" 6 ") {X = Pos.Center() + 6, Y = 7};

var btn7 = new Button (" 7 ") {X = Pos.Center() - 12, Y = 8};
var btn8 = new Button (" 8 ") {X = Pos.Center(), Y = 8};
var btn9 = new Button (" 9 ") {X = Pos.Center() + 6, Y = 8};

var btnAdcao = new Button (" + ") {X = Pos.Center() + 12, Y = 6};
var btnSubtracao = new Button (" - ") {X = Pos.Center() + 12, Y = 7};
var btnMultiplicacao = new Button (" x ") {X = Pos.Center() + 12, Y = 8};

var btnIgual = new Button (" = ") {X = Pos.Center(), Y = 9};

btn1.Clicked += () => Form_the_operation ("1");
btn2.Clicked += () => Form_the_operation ("2");
btn3.Clicked += () => Form_the_operation ("3");

btn4.Clicked += () => Form_the_operation ("4");
btn5.Clicked += () => Form_the_operation ("5");
btn6.Clicked += () => Form_the_operation ("6");

btn7.Clicked += () => Form_the_operation ("7");
btn8.Clicked += () => Form_the_operation ("8");
btn9.Clicked += () => Form_the_operation ("9");

btnAdcao.Clicked += () => Form_the_operation ("+");
btnSubtracao.Clicked += () => Form_the_operation ("-");
btnMultiplicacao.Clicked += () => Form_the_operation ("x");

btnIgual.Clicked += () => Form_the_operation ("=");

win.Add (tela, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnAdcao, btnSubtracao, btnMultiplicacao, btnIgual);
Application.Top.Add (win);
Application.Run ();

Application.Shutdown ();
