using System.Windows.Input;
using TorneSe.EstacionamentoApp.Commands;
using TorneSe.EstacionamentoApp.ViewModels.Base;

namespace TorneSe.EstacionamentoApp.ViewModels;

public class MainViewModel : BaseViewModel
{
    private BaseViewModel _atualViewModel = new HomeViewModel();
    public ICommand AtualizaViewModel { get; set; }

    public BaseViewModel AtualViewModel
    {
        get 
        {
            return _atualViewModel; 
        }
        set 
        {
            _atualViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public MainViewModel()
    {
        AtualizaViewModel = new AtualizarViewCommand(this);
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(AtualViewModel));
    }


}
