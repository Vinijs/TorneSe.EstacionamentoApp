using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Comum;

namespace TorneSe.EstacionamentoApp.Business.Interfaces;

public interface IReservaBusiness
{
    Task<List<ResumoFaturamentoFormaPagamento>> ObterValorFaturamentoPorFormaPagamento();
    Task<List<ResumoFaturamentoMensal>> ObterValorFaturamentoUltimosMeses();
    Task<ResumoOcupacao> ObterPorcentagemOcupacao();
    Task<ResumoUltimaEntrada> ObterUltimaEntrada();
    Task<ResumoUltimaSaida> ObterUltimaSaida();
    Task<List<ResumoFaturamentoMensal>> ObterValorFaturamentoUltimosMeses(DateTime dataInicio, DateTime dataFim);
    Task<List<ResumoFaturamentoFormaPagamento>> ObterValorFaturamentoPorFormaPagamento(DateTime dataInicio, DateTime dataFim);
    Task<int> ObterEntradasNaUltimaHora();
    Task<List<DadosRelatorio>> ObterDadosRelatorio(DateTime dataInicial, DateTime dataFinal);
}
