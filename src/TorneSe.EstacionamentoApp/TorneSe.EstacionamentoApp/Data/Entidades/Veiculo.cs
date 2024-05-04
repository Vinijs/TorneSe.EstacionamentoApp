using System.Collections.Generic;

namespace TorneSe.EstacionamentoApp.Data.Entidades;

public class Veiculo
{
    public int Id { get; set; } 
    public string Placa { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public string Cor { get; set; } = null!;
    public string Ano { get; set; } = null!;
    public ICollection<ReservaVagaVeiculo> Reservas { get; set; } = null!;
    public Vaga Vaga { get; set; }

    public Veiculo()
    {
        Reservas = new List<ReservaVagaVeiculo>();
    }
}
