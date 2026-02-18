using Main.Models;

Console.Clear();
Faculdade faculdade = new();
Login login = new();

faculdade.AddProfessor();
faculdade.PrintList();
faculdade.Login();

Console.ReadLine();
login.Logar();

