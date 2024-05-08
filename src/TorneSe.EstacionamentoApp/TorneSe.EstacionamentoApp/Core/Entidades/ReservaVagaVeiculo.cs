using System;
using TorneSe.EstacionamentoApp.Business.Enums;

namespace TorneSe.EstacionamentoApp.Core.Entidades;

public class ReservaVagaVeiculo
{
    public int Id { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime? HoraSaida { get; set; } = null!;
    public double? HorasUtilizadas { get; set; } = null!;
    public decimal? ValorCobrado { get; set; } = null!;
    public string NomeCondutor { get; set; } = null!;
    public string DocumentoCondutor { get; set; } = null!;
    public FormaPagamento? FormaPagamento { get; set; } = null!;
    public int IdVaga { get; set; }
    public int IdVeiculo { get; set; }
    public Vaga Vaga { get; set; } = null!;
    public Veiculo Veiculo { get; set; } = null!;
}
