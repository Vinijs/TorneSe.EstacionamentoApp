using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Data.Entidades;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Business;

public class VeiculoBusiness : IVeiculoBusiness
{
    public async Task<List<Veiculo>> ObterPorPlaca(string placa) 
        => new List<Veiculo>
        {
            new Veiculo {Id = 1, Placa = "ABC-1234", Modelo = "Fiat", Marca = "Uno", Ano = "2020"},
            new Veiculo {Id = 2, Placa = "DEF-5678", Modelo = "Fiat", Marca = "Palio", Ano = "2020"},
            new Veiculo {Id = 1, Placa = "GHI-9012", Modelo = "Fiat", Marca = "Mobi", Ano = "2022"},
        };
}
