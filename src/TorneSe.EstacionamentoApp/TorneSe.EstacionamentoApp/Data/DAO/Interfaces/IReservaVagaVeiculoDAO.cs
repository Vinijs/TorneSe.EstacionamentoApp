using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

public interface IReservaVagaVeiculoDAO
{
    Task Inserir(ReservaVagaVeiculo reservaVagaVeiculo);
}
