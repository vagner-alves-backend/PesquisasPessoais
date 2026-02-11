using SistemaDeCadastrosCom_JSON.Models;

Login login = new();
Console.Clear();
string nivelLogin = MenuDeNavegacao.MunuInicial() switch
{
    1 => "Aluno",
    2 => "Professor",
    3 => "Administrador",
    _ => "Desconhecido"
};
Console.WriteLine($"O login escolhido foi {nivelLogin}.");
login.Logar(1);
login.Logar(1);
login.Logar(1);