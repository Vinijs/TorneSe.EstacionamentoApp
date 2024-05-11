using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

public interface IReservaVagaVeiculoDAO
{
    Task Inserir(ReservaVagaVeiculo reservaVagaVeiculo);
    Task<ReservaVagaVeiculo?> ObterReservaVagaVeiculo(int idVeiculo, int idVaga);
    Task Atualizar(ReservaVagaVeiculo reservaVaga, ResumoSaida resumoSaida);
    Task<List<ReservaVagaFormaPagamentoDto>> ObterFaturamentoPorFormaPagamento();
    Task<List<ReservaVagaFaturamentoDto>> ObterFaturamentoPorMes();
    Task<ReservaVagaVeiculo> ObterInformacoesUltimaEntrada();
    Task<ReservaVagaVeiculo> ObterInformacoesUltimaSaida();
    Task<List<ReservaVagaFaturamentoDto>> ObterFaturamentoPorMes(DateTime dataInicio, DateTime dataFim);
    Task<IEnumerable<ReservaVagaVeiculo>> ObterDadosRelatorio(DateTime dataInicial, DateTime dataFinal);
    Task<int> ObterEntradasNaUltimaHora();
    Task<List<ReservaVagaFormaPagamentoDto>> ObterFaturamentoPorFormaPagamento(DateTime dataInicio, DateTime dataFim);
}
