using System;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.UI.Args;

public class VagasStoreEventArgs : EventArgs
{
    public VagasStoreEventArgs(ResumoVaga resumoVaga) 
        => ResumoVaga = resumoVaga;
    public ResumoVaga ResumoVaga { get; }
}
