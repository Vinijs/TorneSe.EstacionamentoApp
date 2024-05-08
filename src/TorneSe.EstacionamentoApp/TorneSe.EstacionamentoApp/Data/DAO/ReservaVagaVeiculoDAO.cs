using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

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

    public async Task<ReservaVagaVeiculo> ObterReservaVagaVeiculo(int idVeiculo, int idVaga) 
        => await _contexto.ReservaVagaVeiculos
            .FirstOrDefaultAsync(rv => rv.IdVeiculo == idVeiculo
                                 && rv.IdVaga == idVaga
                                 && rv.HoraSaida == null
                                 && rv.ValorCobrado == null);
}
