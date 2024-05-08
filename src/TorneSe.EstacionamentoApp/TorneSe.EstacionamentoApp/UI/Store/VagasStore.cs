using System;
using System.Collections.Generic;
using System.Linq;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.UI.Args;

namespace TorneSe.EstacionamentoApp.Store;

public class VagasStore
{
    private List<ResumoVaga> _vagasOcupadas;
    private List<ResumoVaga> _vagasLivres;

    public EventHandler<VagasStoreEventArgs>? StoreChanged;
    public VagasStore(List<ResumoVaga> vagasLivres, List<ResumoVaga> vagasOcupadas)
    {

        _vagasOcupadas = vagasOcupadas;
        _vagasLivres = vagasLivres;
    }

    public IReadOnlyList<ResumoVaga> VagasOcupadas => _vagasOcupadas;
    public IReadOnlyList<ResumoVaga> VagasLivres => _vagasLivres;

    public void OcuparVaga(int idVaga, string marca, string modelo, string placa)
    {
        var vaga = _vagasLivres.FirstOrDefault(v => v.IdVaga == idVaga);

        if(vaga is not null)
        {
            vaga.ModeloMarca = $"{modelo}/{marca}";
            vaga.Placa = placa;
            _vagasLivres.Remove(vaga);
            _vagasOcupadas.Add(vaga);
            _vagasOcupadas = _vagasOcupadas.OrderBy(v => v.IdVaga).ToList();
            StoreChanged?.Invoke(this, new VagasStoreEventArgs(vaga));
        }
    }
    
    public void LiberarVaga(int idVaga)
    {
        var vaga = _vagasOcupadas.FirstOrDefault(v => v.IdVaga == idVaga);

        if (vaga is not null)
        {
            _vagasOcupadas.Remove(vaga);
            _vagasLivres.Add(vaga);
            _vagasLivres = _vagasLivres.OrderBy(v => v.IdVaga).ToList();
            StoreChanged?.Invoke(this, new VagasStoreEventArgs(vaga));
        }
    }
}
