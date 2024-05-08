using Microsoft.Extensions.Options;
using System;
using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Business.Enums;
using TorneSe.EstacionamentoApp.Business.Exceptions;
using TorneSe.EstacionamentoApp.Configs;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Store;
using TorneSe.EstacionamentoApp.UI.Dialogs;
using TorneSe.EstacionamentoApp.UI.Helpers;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Dialogs;

public partial class VagaVeiculoSaidaDialog : Window
{
    private readonly IVeiculoBusiness _veiculoBusiness;
    private readonly VagasStore _vagasStore;
    private readonly ResumoVaga _resumoVaga;
    private readonly ConfiguracoesAplicacao _configuracoesAplicacao;
    private ResumoSaida? _resumoSaida;

    private PagamentosDialog _pagamentosDialog;

    public VagaVeiculoSaidaDialog(IVeiculoBusiness veiculoBusiness,
                                  VagasStore vagasStore,
                                  ResumoVaga resumoVaga,
                                  IOptions<ConfiguracoesAplicacao> options)
    {
        InitializeComponent();
        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        _veiculoBusiness = veiculoBusiness;
        _vagasStore = vagasStore;
        _resumoVaga = resumoVaga;
        _configuracoesAplicacao = options.Value;
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
        try
        {
            _resumoSaida = await _veiculoBusiness.ObterResumoSaida(_resumoVaga.IdVeiculo, _resumoVaga.IdVaga);
            _resumoSaida.FormaPagamento = formaPagamento;

            _pagamentosDialog = new PagamentosDialog(_resumoSaida, _configuracoesAplicacao.PathQrCode);
            if (_pagamentosDialog.ShowDialog() is true)
                liberarButton.IsEnabled = true;

        }
        catch (Exception ex)
        {
            if (ex is BusinessException businessException)
                MessageBox.Show(businessException.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Ocorreu um erro ao realizar a saida do veículo", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
    }

    private async void Liberar_ButtonClick(object sender, RoutedEventArgs e)
    {
        if (_resumoSaida is not null)
        {
            try
            {
            
                _vagasStore.LiberarVaga(_resumoVaga.IdVaga);
                await _veiculoBusiness.RealizarSaidaVeiculo(_resumoSaida, _resumoVaga.IdVeiculo, _resumoVaga.IdVaga);
                DialogHelper.GerarTicketSaida(_resumoSaida, _resumoVaga);
            }
            
            catch (Exception ex)
            {
                if (ex is BusinessException businessException)
                    MessageBox.Show(businessException.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("Ocorreu um erro ao realizar a saida do veículo", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Close();
            }
        }
    }

    private void Cancelar_ButtonClick(object sender, RoutedEventArgs e) 
        => Close();
}
