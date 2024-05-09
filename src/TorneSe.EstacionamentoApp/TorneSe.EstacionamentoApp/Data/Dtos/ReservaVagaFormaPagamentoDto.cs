using TorneSe.EstacionamentoApp.Business.Enums;

namespace TorneSe.EstacionamentoApp.Data.Dtos;

public record struct ReservaVagaFormaPagamentoDto(FormaPagamento FormaPagamento, decimal ValorCobrado);
