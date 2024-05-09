using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.Business;

public sealed class ReservaBusiness : IReservaBusiness
{
    private readonly IVagaDAO _vagaDAO;
    private readonly IReservaVagaVeiculoDAO _reservaVagaVeiculoDAO;

    public ReservaBusiness(IVagaDAO vagaDAO, IReservaVagaVeiculoDAO reservaVagaVeiculoDAO)
    {
        _vagaDAO = vagaDAO;
        _reservaVagaVeiculoDAO = reservaVagaVeiculoDAO;
    }

    public async Task<ResumoOcupacao> ObterPorcentagemOcupacao()
    {
        var totalVagas = await _vagaDAO.ObterContagemDeVagas();
        var vagasOcupadas = await _vagaDAO.ObterContagemDeVagasOcupadas();
        var vagasLivres = totalVagas - vagasOcupadas;

        var porcentagemVagasOcupadas = (vagasOcupadas * 100) / (double)totalVagas;
        var porcentagemVagasLivres = (vagasLivres * 100) / (double)totalVagas;

        return new ResumoOcupacao
        {
            Ocupadas = Math.Round(porcentagemVagasOcupadas, 2),
            Livres = Math.Round(porcentagemVagasLivres, 2)
        };

    }

    public async Task<List<ResumoFaturamentoFormaPagamento>> ObterValorFaturamentoPorFormaPagamento()
    {
        var faturamento = new List<ResumoFaturamentoFormaPagamento>();
        var dadosFaturamento =
            await _reservaVagaVeiculoDAO.ObterFaturamentoPorFormaPagamento();

        faturamento = dadosFaturamento
            .GroupBy(x => x.FormaPagamento)
            .Select(x => new ResumoFaturamentoFormaPagamento
            {
                FormaPagamento = x.Key,
                ValorAgregado = decimal.ToDouble(x.Sum(y => y.ValorCobrado))
            }).ToList();


        return faturamento;
    }

    public async Task<List<ResumoFaturamentoMensal>> ObterValorFaturamentoUltimosMeses()
    {
        var faturamento = new List<ResumoFaturamentoMensal>();

        var dadosFaturamento = await _reservaVagaVeiculoDAO.ObterFaturamentoPorMes();

        faturamento = dadosFaturamento
            .GroupBy(x => x.HoraSaida.ToString("MMM"))
            .Select(x => new ResumoFaturamentoMensal
            {
                Mes = x.Key,
                ValorAgregado = decimal.ToDouble(x.Sum(y => y.ValorCobrado))
            }).ToList();

        return faturamento;
    }
}
