using System.Collections.Generic;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class ReservaVagaVeiculoDAO : IReservaVagaVeiculoDAO
{
    private readonly List<ReservaVagaVeiculo> _reservaVagaVeiculos;

    public ReservaVagaVeiculoDAO(EstacionamentoContexto contexto) 
        => _reservaVagaVeiculos = contexto.ReservaVagaVeiculos;
}
