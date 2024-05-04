using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class VagaDAO: IVagaDAO
{
    private readonly EstacionamentoContexto _contexto;

    public VagaDAO(EstacionamentoContexto contexto) 
        => _contexto = contexto;

    public async Task MarcarComoOcupada(int idVaga, int idVeiculo)
    {
        var vaga = await _contexto.Vagas.FirstOrDefaultAsync(v => v.Id == idVaga);
        
        if(vaga is not null)
        {
            vaga.Ocupada = true;
            vaga.IdVeiculo = idVeiculo;
        }

        await _contexto.SaveChangesAsync();
    }
}
