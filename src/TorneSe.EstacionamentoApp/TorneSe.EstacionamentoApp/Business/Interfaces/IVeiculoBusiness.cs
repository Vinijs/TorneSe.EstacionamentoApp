using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.UI.Interfaces;

public interface IVeiculoBusiness
{
    Task<List<Veiculo>> ObterPorPlaca(string placa);
    Task RealizarEntradaVeiculo(Veiculo veiculo, int idVaga);

}
