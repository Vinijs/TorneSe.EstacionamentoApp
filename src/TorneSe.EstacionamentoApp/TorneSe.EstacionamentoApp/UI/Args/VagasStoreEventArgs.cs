using System;
using TorneSe.EstacionamentoApp.Core.Comum;

namespace TorneSe.EstacionamentoApp.UI.Args;

public class VagasStoreEventArgs : EventArgs
{
    public VagasStoreEventArgs(ResumoVaga resumoVaga) 
        => ResumoVaga = resumoVaga;
    public ResumoVaga ResumoVaga { get; }
}
