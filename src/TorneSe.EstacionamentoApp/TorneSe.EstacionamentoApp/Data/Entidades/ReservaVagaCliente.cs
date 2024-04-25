using System;

namespace TorneSe.EstacionamentoApp.Data.Entidades;

public class ReservaVagaCliente
{
    public int Id { get; set; }
    public int IdVaga { get; set; }
    public int IdCliente { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime HoraSaida { get; set; }
    public double? HorasUtilizadas { get; set; }
    public decimal? ValorCobrado { get; set; }
    public Vaga Vaga { get; set; }
    public Cliente Cliente { get; set; }
}
