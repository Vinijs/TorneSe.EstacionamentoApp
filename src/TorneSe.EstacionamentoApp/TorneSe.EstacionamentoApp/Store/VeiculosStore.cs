using System.Collections.Generic;
using System.Linq;
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
        CriarVagasLivres();
    }

    public IReadOnlyList<Vaga> VagasOcupadas => _vagasOcupadas;
    public IReadOnlyList<Vaga> VagasLivres => _vagasLivres;

    private void CriarVagasLivres()
    {
        var vagasPrimeiroAndar = Enumerable.Range(1, 20).Select(x => new Vaga
        {
            Codigo = "A",
            Numero = x,
            Ocupada = false
        })
            .ToList();

        var vagasSegundoAndar = Enumerable.Range(1, 15).Select(i => new Vaga
        {
            Codigo = "B",
            Numero = i,
            Ocupada = false
        })
            .ToList();

        _vagasLivres.AddRange(vagasPrimeiroAndar);
        _vagasLivres.AddRange(vagasSegundoAndar);
    }
}
