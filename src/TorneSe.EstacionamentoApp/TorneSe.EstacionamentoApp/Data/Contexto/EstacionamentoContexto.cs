using System.Collections.Generic;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.Contexto;

public class EstacionamentoContexto
{
    public List<Veiculo> Veiculos { get; set; } = new List<Veiculo> {
            new Veiculo { Id = 1, Placa = "ABC-1234", Modelo = "Fiat", Marca = "Uno", Ano = "2020" },
            new Veiculo { Id = 2, Placa = "DEF-5678", Modelo = "Fiat", Marca = "Palio", Ano = "2020" },
            new Veiculo { Id = 3, Placa = "GHI-9012", Modelo = "Fiat", Marca = "Mobi", Ano = "2022" },
        };
    public List<Vaga> Vagas { get; set; } = new List<Vaga>();
    public List<ReservaVagaVeiculo> ReservaVagaVeiculos { get; set; } = new List<ReservaVagaVeiculo>();


}
