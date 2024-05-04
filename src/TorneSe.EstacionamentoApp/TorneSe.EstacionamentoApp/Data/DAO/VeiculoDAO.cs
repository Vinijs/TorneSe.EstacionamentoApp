using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class VeiculoDAO: IVeiculoDAO
{
    private readonly EstacionamentoContexto _contexto;
    public VeiculoDAO(EstacionamentoContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Veiculo>> BuscarVeiculosPorPlaca(string placa) 
        => await _contexto.Veiculos.Where(v => v.Placa.Contains(placa)).Take(10).ToListAsync();

    public async Task<int> Inserir(Veiculo veiculo)
    {
        await _contexto.Veiculos.AddAsync(veiculo);
        await _contexto.SaveChangesAsync();
        return  veiculo.Id;
    }
}
