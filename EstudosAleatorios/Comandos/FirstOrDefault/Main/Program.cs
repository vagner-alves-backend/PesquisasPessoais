using Main.Models;
List<Pessoas> pessoas = [
    new("Vágner", "123"),
    new("Sabrine", "321"),
    new("Sofia", "345")
];

bool valid = pessoas.FirstOrDefault(p => p.Name == "Vágner" && p.Senha == "123") != null;
Console.WriteLine(valid);
valid = pessoas.Any(p => p.Name == "Sabrine" && p.Senha == "321");
Console.WriteLine(valid);
var valor = pessoas.FirstOrDefault(p => p.Name == "Vágner" && p.Senha == "123");
Console.WriteLine($"--- {valor?.Name} senha {valor?.Senha}");
