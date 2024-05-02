using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

public interface IVeiculoDAO
{
    Task<List<Veiculo>> BuscarVeiculosPorPlaca(string placa);
}
