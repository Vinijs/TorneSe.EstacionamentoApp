using System.Collections.Generic;
using System.Linq;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class VagaDAO: IVagaDAO
{
    private readonly List<Vaga> _vagas;

    public VagaDAO(EstacionamentoContexto contexto) 
        => _vagas = contexto.Vagas;

    public void MarcarComoOcupada(int idVaga)
    {
        var vaga = _vagas.FirstOrDefault(v => v.Id == idVaga);
        
        if(vaga is not null)
        {
            vaga.Ocupada = true;
        }


    }
}
