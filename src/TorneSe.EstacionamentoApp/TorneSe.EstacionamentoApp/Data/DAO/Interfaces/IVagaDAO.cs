using System.Threading.Tasks;

namespace TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

public interface IVagaDAO
{
    Task MarcarComoOcupada(int idVaga, int idVeiculo);
    Task<bool> ExisteVagaOcupadaComVeiculoInformado(int idVeiculo);
}
