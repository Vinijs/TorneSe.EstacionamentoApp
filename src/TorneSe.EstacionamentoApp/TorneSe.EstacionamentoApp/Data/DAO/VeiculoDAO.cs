using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class VeiculoDAO: IVeiculoDAO
{
    private readonly List<Veiculo> _veiculos;
    public VeiculoDAO(EstacionamentoContexto contexto)
    {
        _veiculos = contexto.Veiculos;
    }

    public Task<List<Veiculo>> BuscarVeiculosPorPlaca(string placa) 
        => Task.FromResult(_veiculos.Where(v => v.Placa.Contains(placa)).Take(10).ToList());

    public async Task<int> Inserir(Veiculo veiculo)
    {
        _veiculos.Add(veiculo);
        return  Random.Shared.Next(0, _veiculos.Count);
    }
}
