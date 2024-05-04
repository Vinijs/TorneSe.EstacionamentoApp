using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class ReservaVagaVeiculoDAO : IReservaVagaVeiculoDAO
{
    private readonly EstacionamentoContexto _contexto;

    public ReservaVagaVeiculoDAO(EstacionamentoContexto contexto) 
        => _contexto = contexto;

    public async Task Inserir(ReservaVagaVeiculo reservaVagaVeiculo)
    {
        await _contexto.ReservaVagaVeiculos.AddAsync(reservaVagaVeiculo);
        await _contexto.SaveChangesAsync();
    }
}
