using System.IO;

string? filePath = "Arquivo/arq.txt";
// using var reader = new StreamReader(filePath);
// while (await reader.ReadLineAsync() is { } line)
// {
//     Console.WriteLine(line);
// }
using var writer = new StreamWriter(filePath);
try
{
    await writer.WriteLineAsync("Linha 3 - Adicionada.");
} 
catch (Exception ex)
{
    Console.WriteLine($"Não foi possível gravar o texto no arquivo.\n[Erro]:{ex.Message}");
}
finally
{
    writer?.Close();
}

try
{
    using var reader = new StreamReader(filePath);
    while (await reader.ReadLineAsync() is { } line)
    {
        Console.WriteLine(line);
    }
} catch (Exception ex)
{
    Console.WriteLine($"Não foi possível acessar o arquivo.\n[Erro]: {ex.Message}");
}finally
{
    Console.WriteLine("Fim da leitura do arquivo.");
}




// string? arquivoCaminho = "Arquivo/arq.txt";
// string[]? linhas = File.ReadAllLines(arquivoCaminho);
// foreach (string? linha in linhas)
// {
//     Console.WriteLine(linha);
// }
