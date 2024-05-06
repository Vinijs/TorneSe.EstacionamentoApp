using System;
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
        try
        {
            await _contexto.ReservaVagaVeiculos.AddAsync(reservaVagaVeiculo);

            _ = await _contexto.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
