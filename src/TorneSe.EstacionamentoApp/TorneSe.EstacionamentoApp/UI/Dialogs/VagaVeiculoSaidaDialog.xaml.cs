using System;
using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Business.Enums;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Store;
using TorneSe.EstacionamentoApp.UI.Dialogs;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Dialogs;

public partial class VagaVeiculoSaidaDialog : Window
{
    private readonly IVeiculoBusiness _veiculoBusiness;
    private readonly VagasStore _vagasStore;
    private readonly ResumoVaga _resumoVaga;

    private PagamentosDialog _pagamentosDialog;

    public VagaVeiculoSaidaDialog(IVeiculoBusiness veiculoBusiness,
                                  VagasStore vagasStore,
                                  ResumoVaga resumoVaga)
    {
        InitializeComponent();
        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        _veiculoBusiness = veiculoBusiness;
        _vagasStore = vagasStore;
        _resumoVaga = resumoVaga;
        MontarComponente();
    }

    private void MontarComponente()
    {
        dadosModeloMarcaTextBlock.Text = _resumoVaga.ModeloMarca;
        dadosPlacaTextblock.Text = _resumoVaga.Placa;
        dadosVagaTextBlock.Text = _resumoVaga.NomeVaga;
    }

    private async void Pagar_ButtonClick(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            return;

        var formaPagamento = Enum.Parse<FormaPagamento>(button.CommandParameter.ToString()!);

        var resumoSaida = await _veiculoBusiness.ObterResumoSaida(_resumoVaga.IdVeiculo, _resumoVaga.IdVaga);
        resumoSaida.FormaPagamento = formaPagamento;

        _pagamentosDialog = new PagamentosDialog(resumoSaida);
        _pagamentosDialog.ShowDialog();        
    }

    private void Cancelar_ButtonClick(object sender, RoutedEventArgs e) 
        => Close();
}
