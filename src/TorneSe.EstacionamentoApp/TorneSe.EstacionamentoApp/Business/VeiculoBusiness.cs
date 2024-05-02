using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;
using TorneSe.EstacionamentoApp.Data.Entidades;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Business;

public class VeiculoBusiness : IVeiculoBusiness
{
    private readonly IVeiculoDAO _veiculoDAO;
    public VeiculoBusiness(IVeiculoDAO veiculoDAO) 
        => _veiculoDAO = veiculoDAO;
    public async Task<List<Veiculo>> ObterPorPlaca(string placa) 
        => await _veiculoDAO.BuscarVeiculosPorPlaca(placa);
}
