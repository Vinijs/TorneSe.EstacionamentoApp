using System.Collections.Generic;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Store;

public class VeiculosStore
{
    private List<Vaga> _vagasOcupadas;
    private List<Vaga> _vagasLivres;

    public VeiculosStore()
    {
        _vagasOcupadas = new();
        _vagasLivres = new();
    }

    public IReadOnlyList<Vaga> VagasOcupadas => _vagasOcupadas;
    public IReadOnlyList<Vaga> VagasLivres => _vagasLivres;
}
