using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

public interface IReservaVagaVeiculoDAO
{
    Task Inserir(ReservaVagaVeiculo reservaVagaVeiculo);
    Task<ReservaVagaVeiculo?> ObterReservaVagaVeiculo(int idVeiculo, int idVaga);
}
