using System.Collections.Generic;

namespace TorneSe.EstacionamentoApp.Core.Entidades;

public class Vaga
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public int Numero { get; set; }
    public bool Ocupada { get; set; }
    public int Andar { get; set; }
    public string Nome => $"{Codigo}-{Numero}";
    public int? IdVeiculo { get; set; }
    public Veiculo Veiculo { get; set; } = null!;
    public ICollection<ReservaVagaVeiculo> Reservas { get; set; }

    public Vaga()
    {
        Reservas = new List<ReservaVagaVeiculo>();
    }
}
