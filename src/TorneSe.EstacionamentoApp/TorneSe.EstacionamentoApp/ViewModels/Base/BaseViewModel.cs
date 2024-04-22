using System;
using System.ComponentModel;

namespace TorneSe.EstacionamentoApp.ViewModels.Base;

public class BaseViewModel : INotifyPropertyChanged, IDisposable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string nomePropriedade)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
    }

    public virtual void Dispose()
    {}
}
