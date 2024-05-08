using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class VagaDAO: IVagaDAO
{
    private readonly EstacionamentoContexto _contexto;

    public VagaDAO(EstacionamentoContexto contexto) 
        => _contexto = contexto;

    public async Task<bool> ExisteVagaOcupadaComVeiculoInformado(int idVeiculo) 
        => await _contexto.Vagas.AnyAsync(v => v.IdVeiculo == idVeiculo && v.Ocupada);

    public async Task MarcarComoLivre(int idVaga)
    {
        var vaga = await _contexto.Vagas.FirstOrDefaultAsync(v => v.Id == idVaga);

        if (vaga is not null)
        {
            vaga.Ocupada = false;
            vaga.IdVeiculo = null;

            await _contexto.SaveChangesAsync();
        }
    }

    public async Task MarcarComoOcupada(int idVaga, int idVeiculo)
    {
            var vaga = await _contexto.Vagas.FirstOrDefaultAsync(v => v.Id == idVaga);

            if (vaga is not null)
            {
                vaga.Ocupada = true;
                vaga.IdVeiculo = idVeiculo;
                
                await _contexto.SaveChangesAsync();
            }
    }
}
