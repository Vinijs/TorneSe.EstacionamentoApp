using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.UI.Interfaces;

public interface IVeiculoBusiness
{
    Task<List<Veiculo>> ObterPorPlaca(string placa);
    Task RealizarEntradaVeiculo(Veiculo veiculo, int idVaga, string nomeCondutor, string documentoCondutor);
    Task<ResumoSaida> ObterResumoSaida(int idVeiculo, int idVaga);
}
