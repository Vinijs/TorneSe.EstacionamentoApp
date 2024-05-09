using System;

namespace TorneSe.EstacionamentoApp.Data.Dtos;

public record struct ReservaVagaFaturamentoDto(DateTime HoraSaida, decimal ValorCobrado);
