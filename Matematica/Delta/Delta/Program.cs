using Delta.Models;

MyDelta delta;
(double delta, double x1, double x2) deltaR;
try
{
    delta = new ("1", "-3", "-10");
    deltaR = delta.ValueX();
    Console.WriteLine (
        "\t--Resposta...\n"+
        $"Delta : {deltaR.delta}\n"+
        $"x¹ = {deltaR.x1}\n"+
        $"x² = {deltaR.x2}\n"+
        "--------------------------"
    );
} catch (Exception ex)
{
    Console.WriteLine (ex.Message);
}