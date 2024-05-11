using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Business.Enums;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class ReservaVagaVeiculoDAO : IReservaVagaVeiculoDAO
{
    private readonly EstacionamentoContexto _contexto;

    public ReservaVagaVeiculoDAO(EstacionamentoContexto contexto) 
        => _contexto = contexto;

    public async Task Atualizar(ReservaVagaVeiculo reservaVaga, ResumoSaida resumoSaida)
    {
        reservaVaga.HoraSaida = resumoSaida.HoraSaida;
        reservaVaga.ValorCobrado = resumoSaida.ValorTotal;
        reservaVaga.FormaPagamento = resumoSaida.FormaPagamento;
        reservaVaga.HorasUtilizadas = resumoSaida.TotalHoras;

        _contexto.ReservaVagaVeiculos.Update(reservaVaga);
        _ = await _contexto.SaveChangesAsync();
    }

    public async Task Inserir(ReservaVagaVeiculo reservaVagaVeiculo)
    {
            await _contexto.ReservaVagaVeiculos.AddAsync(reservaVagaVeiculo);

            _ = await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<ReservaVagaVeiculo>> ObterDadosRelatorio(DateTime dataInicial, DateTime dataFinal) 
        => await _contexto.ReservaVagaVeiculos
               .Include(rv => rv.Vaga)
               .Include(rv => rv.Veiculo)
               .Where(rv => rv.HoraSaida != null
                      && rv.ValorCobrado != null
                      && rv.HoraSaida >= dataInicial
                      && rv.HoraSaida <= dataFinal)
                .ToListAsync();

    public async Task<int> ObterEntradasNaUltimaHora() 
        => await _contexto.ReservaVagaVeiculos
            .Where(rv => rv.HoraEntrada >= DateTime.Now.AddHours(-1))
            .CountAsync();

    public async Task<List<ReservaVagaFormaPagamentoDto>> ObterFaturamentoPorFormaPagamento() 
        => await _contexto.ReservaVagaVeiculos
            .Where(rv => rv.HoraSaida != null
                         && rv.ValorCobrado != null && rv.FormaPagamento != null)
            .Select(rv => new ReservaVagaFormaPagamentoDto
            {
                FormaPagamento = (FormaPagamento)rv.FormaPagamento!,
                ValorCobrado = rv.ValorCobrado!.Value
            })
            .ToListAsync();

    public async Task<List<ReservaVagaFormaPagamentoDto>> ObterFaturamentoPorFormaPagamento(DateTime dataInicio, DateTime dataFim) 
        => await _contexto.ReservaVagaVeiculos
                    .Where(rv => rv.HoraSaida != null
                           && rv.ValorCobrado != null
                           && rv.FormaPagamento != null
                           && rv.HoraSaida >= dataInicio
                           && rv.HoraSaida <= dataFim)
                    .Select(rv => new ReservaVagaFormaPagamentoDto
                    {
                        FormaPagamento = (FormaPagamento)rv.FormaPagamento!,
                        ValorCobrado = rv.ValorCobrado!.Value
                    })
                    .ToListAsync();
    public async Task<List<ReservaVagaFaturamentoDto>> ObterFaturamentoPorMes() 
        => await _contexto.ReservaVagaVeiculos
            .Where(rv => rv.HoraSaida != null
                            && rv.ValorCobrado != null)
            .Select(rv => new ReservaVagaFaturamentoDto
            {
                HoraSaida = rv.HoraSaida!.Value,
                ValorCobrado = rv.ValorCobrado!.Value
            })
            .ToListAsync();

    public async Task<List<ReservaVagaFaturamentoDto>> ObterFaturamentoPorMes(DateTime dataInicio, DateTime dataFim)
    {
        return await _contexto.ReservaVagaVeiculos
                .Where(rv => rv.HoraSaida != null
                       && rv.ValorCobrado != null
                       && rv.HoraSaida >= dataInicio
                       && rv.HoraSaida <= dataFim)
                .Select(rv => new ReservaVagaFaturamentoDto
                {
                    HoraSaida = rv.HoraSaida!.Value,
                    ValorCobrado = rv.ValorCobrado!.Value
                })
                .ToListAsync();
    }

    public async Task<ReservaVagaVeiculo?> ObterInformacoesUltimaEntrada() 
        => await _contexto.ReservaVagaVeiculos
            .Include(rv => rv.Vaga)
            .Include(rv => rv.Veiculo)
            .Where(rv => rv.HoraSaida == null
                         && rv.ValorCobrado == null)
            .OrderByDescending(rv => rv.HoraEntrada)
            .FirstOrDefaultAsync();

    public async Task<ReservaVagaVeiculo?> ObterInformacoesUltimaSaida() 
        => await _contexto.ReservaVagaVeiculos
            .Include(rv => rv.Vaga)
            .Include(rv => rv.Veiculo)
            .Where(rv => rv.HoraSaida != null
                         && rv.ValorCobrado != null)
            .OrderByDescending(rv => rv.HoraSaida)
            .FirstOrDefaultAsync();

    public async Task<ReservaVagaVeiculo> ObterReservaVagaVeiculo(int idVeiculo, int idVaga) 
        => await _contexto.ReservaVagaVeiculos
            .FirstOrDefaultAsync(rv => rv.IdVeiculo == idVeiculo
                                 && rv.IdVaga == idVaga
                                 && rv.HoraSaida == null
                                 && rv.ValorCobrado == null);
}
