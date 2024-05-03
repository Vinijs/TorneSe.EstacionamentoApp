using System;

namespace TorneSe.EstacionamentoApp.Data.Entidades;

public class ReservaVagaVeiculo
{
    public int Id { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime HoraSaida { get; set; }
    public double? HorasUtilizadas { get; set; }
    public decimal? ValorCobrado { get; set; }
    public int IdVaga { get; set; }
    public int IdVeiculo { get; set; }
    public Vaga Vaga { get; set; }
    public Veiculo Veiculo { get; set; }
}
