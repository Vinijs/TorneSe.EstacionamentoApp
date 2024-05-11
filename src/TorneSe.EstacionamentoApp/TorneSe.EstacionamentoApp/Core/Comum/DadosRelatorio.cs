namespace TorneSe.EstacionamentoApp.Core.Comum;

public record struct DadosRelatorio(string Vaga, string Placa, string ValorCobrado,
                                    string HorasEntrada, string HoraSaida,
                                    string HorasUtilizadas, string FormaPagamento);
