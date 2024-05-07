using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class VeiculoDAO: IVeiculoDAO
{
    private readonly EstacionamentoContexto _contexto;
    public VeiculoDAO(EstacionamentoContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Veiculo>> BuscarVeiculosPorPlaca(string placa) 
        => await _contexto.Veiculos
                 .Include(v => v.Vaga)
                 .Where(v => v.Placa.Contains(placa) && v.Vaga == null)
                 .Take(10).ToListAsync();

    public async Task<bool> ExisteVeiculoComPlaca(string placa) 
        => await _contexto.Veiculos.AnyAsync(v => v.Placa == placa);

    public async Task<int> Inserir(Veiculo veiculo)
    {
        try
        {
            await _contexto.Veiculos.AddAsync(veiculo);
            await _contexto.SaveChangesAsync();
            return veiculo.Id;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
}
