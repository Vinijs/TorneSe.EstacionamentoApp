using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

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

    public async Task<List<DadosRelatorio>> ObterDadosRelatorio(DateTime dataInicial, DateTime dataFinal)
    {
        var reservas = await _reservaVagaVeiculoDAO.ObterDadosRelatorio(dataInicial, dataFinal);

        return reservas.Select(rv => new DadosRelatorio
        {
            Vaga = rv.Vaga.Nome,
            Placa = rv.Veiculo.Placa,
            HoraSaida = rv.HoraSaida!.Value.ToString("dd/MM/yyyy HH:mm:ss")!,
            ValorCobrado = rv.ValorCobrado!.Value.ToString(),
            FormaPagamento = rv.FormaPagamento!.Value.ToString()!,
            HorasEntrada = rv.HoraEntrada!.ToString("dd/MM/yyyy HH:mm:ss"),
            HorasUtilizadas = rv.HorasUtilizadas.ToString()!
        }).ToList();
    }

    public async Task<int> ObterEntradasNaUltimaHora() 
        => await _reservaVagaVeiculoDAO.ObterEntradasNaUltimaHora();

    public async Task<ResumoOcupacao> ObterPorcentagemOcupacao()
    {
        var totalVagas = await _vagaDAO.ObterContagemDeVagas();
        var vagasOcupadas = await _vagaDAO.ObterContagemDeVagasOcupadas();
        var vagasLivres = totalVagas - vagasOcupadas;

        var porcentagemVagasOcupadas = (vagasOcupadas * 100) / (double)totalVagas;
        var porcentagemVagasLivres = (vagasLivres * 100) / (double)totalVagas;

        return new ResumoOcupacao
        {
            QuantidadeOcupadas = vagasOcupadas,
            Ocupadas = Math.Round(porcentagemVagasOcupadas, 2),
            Livres = Math.Round(porcentagemVagasLivres, 2),
            QuantidadeLivres = vagasLivres
        };

    }

    public async Task<ResumoUltimaEntrada> ObterUltimaEntrada()
    {
        ReservaVagaVeiculo? reservaVaga = await _reservaVagaVeiculoDAO.ObterInformacoesUltimaEntrada();

        if (reservaVaga == null)
            return new ResumoUltimaEntrada(string.Empty, string.Empty, default);

        return new ResumoUltimaEntrada(reservaVaga.Veiculo.Placa, reservaVaga.Vaga.Nome, reservaVaga.HoraEntrada);
    }

    public async Task<ResumoUltimaSaida> ObterUltimaSaida()
    {
        ReservaVagaVeiculo? reservaVaga = await _reservaVagaVeiculoDAO.ObterInformacoesUltimaSaida();

        if (reservaVaga == null)
            return new ResumoUltimaSaida(string.Empty, string.Empty, default);

        return new ResumoUltimaSaida(reservaVaga.Veiculo.Placa, reservaVaga.Vaga.Nome, (DateTime)reservaVaga.HoraSaida!);
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

    public async Task<List<ResumoFaturamentoFormaPagamento>> ObterValorFaturamentoPorFormaPagamento(DateTime dataInicio, DateTime dataFim)
    {
        var faturamento = new List<ResumoFaturamentoFormaPagamento>();
        var dadosFaturamento =
            await _reservaVagaVeiculoDAO.ObterFaturamentoPorFormaPagamento(dataInicio, dataFim);

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

    public async Task<List<ResumoFaturamentoMensal>> ObterValorFaturamentoUltimosMeses(DateTime dataInicio, DateTime dataFim)
    {
        var faturamento = new List<ResumoFaturamentoMensal>();

        var dadosFaturamento = await _reservaVagaVeiculoDAO.ObterFaturamentoPorMes(dataInicio,dataFim);

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
