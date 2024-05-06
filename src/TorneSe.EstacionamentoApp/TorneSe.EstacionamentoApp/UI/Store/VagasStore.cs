using System;
using System.Collections.Generic;
using System.Linq;
using TorneSe.EstacionamentoApp.Data.Dtos;
using TorneSe.EstacionamentoApp.UI.Args;

namespace TorneSe.EstacionamentoApp.Store;

public class VagasStore
{
    private readonly List<ResumoVaga> _vagasOcupadas;
    private readonly List<ResumoVaga> _vagasLivres;

    public EventHandler<VagasStoreEventArgs>? StoreChanged;
    public VagasStore(List<ResumoVaga> vagasLivres, List<ResumoVaga> vagasOcupadas)
    {

        _vagasOcupadas = vagasOcupadas;
        _vagasLivres = vagasLivres;
    }

    public IReadOnlyList<ResumoVaga> VagasOcupadas => _vagasOcupadas;
    public IReadOnlyList<ResumoVaga> VagasLivres => _vagasLivres;

    public void CriarVagasOcupadas()
    {

        var vagasOcupadasPrimeiroAndar = Enumerable.Range(1, 20)
            .Select(x => new ResumoVaga(x, $"A-{x}", "HGT-9878", "Golf/Volkswagen"))
            .ToList();

        var vagasOcupadasSegundoAndar = Enumerable.Range(1, 15)
            .Select(x => new ResumoVaga(x, $"B-{x}", "NAH-0987", "Corsa/Chevrolet"))
            .ToList();

        _vagasOcupadas.AddRange(vagasOcupadasPrimeiroAndar);
        _vagasOcupadas.AddRange(vagasOcupadasSegundoAndar);
    }

    public void OcuparVaga(int idVaga)
    {
        var vaga = _vagasLivres.FirstOrDefault(v => v.IdVaga == idVaga);

        if(vaga is not null)
        {
            _vagasLivres.Remove(vaga);
            _vagasOcupadas.Add(vaga);
            StoreChanged?.Invoke(this, new VagasStoreEventArgs(vaga));
        }
    }
    
    public void LiberarVaga(int idVaga)
    {
        var vaga = _vagasLivres.FirstOrDefault(v => v.IdVaga == idVaga);

        if (vaga is not null)
        {
            _vagasOcupadas.Remove(vaga);
            _vagasLivres.Add(vaga);
            StoreChanged?.Invoke(this, new VagasStoreEventArgs(vaga));
        }
    }
}
