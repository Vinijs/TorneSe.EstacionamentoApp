using TorneSe.EstacionamentoApp.Business.Enums;

namespace TorneSe.EstacionamentoApp.Core.Comum;

public record struct ResumoFaturamentoFormaPagamento(FormaPagamento FormaPagamento, double ValorAgregado);
