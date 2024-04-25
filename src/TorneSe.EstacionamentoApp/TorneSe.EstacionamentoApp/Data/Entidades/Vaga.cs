namespace TorneSe.EstacionamentoApp.Data.Entidades;

public class Vaga
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public int Numero { get; set; }
    public bool Ocupada { get; set; }
    public int Andar { get; set; }
    public string Nome => $"{Codigo}-{Numero}";
    public int? IdVeiculo { get; set; }
    public Veiculo Veiculo { get; set; }
}
