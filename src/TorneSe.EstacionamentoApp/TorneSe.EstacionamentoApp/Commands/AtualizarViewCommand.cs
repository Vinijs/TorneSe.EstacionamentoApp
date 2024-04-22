using System;
using System.Windows.Input;
using TorneSe.EstacionamentoApp.ViewModels;
using TorneSe.EstacionamentoApp.ViewModels.Base;

namespace TorneSe.EstacionamentoApp.Commands;

public class AtualizarViewCommand : ICommand
{
    private readonly MainViewModel _mainViewModel;
    public event EventHandler? CanExecuteChanged;

    public AtualizarViewCommand(MainViewModel mainViewModel) 
        => _mainViewModel = mainViewModel;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is null)
            return;

        BaseViewModel view = parameter.ToString() switch
        {
            "Home" => new HomeViewModel(),
            "Entrada Veiculos" => new EntradaVeiculosViewModel(),
            "Saida Veiculos" => new SaidaVeiculosViewModel(),
            "Relatorios" => new RelatoriosViewModel(),
            "Usuarios" => new UsuariosViewModel(),
            "Configuracoes" => new ConfiguracoesViewModel()
        };

        _mainViewModel.AtualViewModel = view;
    }
}
