using System.Collections.Generic;
using System.Linq;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.Store;

public class VeiculosStore
{
    private readonly List<ResumoVaga> _vagasOcupadas;
    private readonly List<ResumoVaga> _vagasLivres;

    public VeiculosStore()
    {
        _vagasOcupadas = new();
        _vagasLivres = new();
        CriarVagasLivres();
        CriarVagasOcupadas();
    }

    public IReadOnlyList<ResumoVaga> VagasOcupadas => _vagasOcupadas;
    public IReadOnlyList<ResumoVaga> VagasLivres => _vagasLivres;

    private void CriarVagasLivres()
    {
        var vagasPrimeiroAndar = Enumerable.Range(1, 20)
            .Select(x => new ResumoVaga($"A-{x}"))
            .ToList();

        var vagasSegundoAndar = Enumerable.Range(1, 15)
            .Select(x => new ResumoVaga($"B-{x}"))
            .ToList();

        _vagasLivres.AddRange(vagasPrimeiroAndar);
        _vagasLivres.AddRange(vagasSegundoAndar);
    }

    public void CriarVagasOcupadas()
    {
        var vagasOcupadasPrimeiroAndar = Enumerable.Range(1, 20)
            .Select(x => new ResumoVaga($"A-{x}", "NAH-0987", "José Ferreira"))
            .ToList();

        var vagasOcupadasSegundoAndar = Enumerable.Range(1, 15)
            .Select(x => new ResumoVaga($"B-{x}", "NAH-0987", "José Ferreira"))
            .ToList();

        _vagasOcupadas.AddRange(vagasOcupadasPrimeiroAndar);
        _vagasOcupadas.AddRange(vagasOcupadasSegundoAndar);
    }
}
