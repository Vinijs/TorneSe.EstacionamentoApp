using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using TorneSe.EstacionamentoApp.Data.Entidades;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Dialogs;

/// <summary>
/// Lógica interna para VagaVeiculoDialog.xaml
/// </summary>
public partial class VagaVeiculoEntradaDialog : Window
{
    private readonly Thickness _bordaPadrao;
    private readonly Brush _corPadrao;
    private readonly Visibility _visibilidadepadrao;
    private readonly IVeiculoBusiness _veiculoBusiness;

    public VagaVeiculoEntradaDialog(IVeiculoBusiness veiculoBusiness)
    {
        InitializeComponent();
        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        _bordaPadrao = placaTextBox.BorderThickness;
        _corPadrao = corTextBox.BorderBrush;
        _visibilidadepadrao = placaInvalidaTextBlock.Visibility;
        _veiculoBusiness = veiculoBusiness;
        //placaVeiculoComboBox.ItemsSource = _veiculoBusiness.ObterPorPlaca("").Result;
    }

    private void Cancelar_Click(object sender, RoutedEventArgs e) 
        => Close();

    private void Confirmar_Click(object sender, RoutedEventArgs e)
    {
        LimparFormatacaoErros();
        var camposValidos = ValidarCamposFormulario();

        if (camposValidos)
        {

        }
    }

    private void LimparFormatacaoErros()
    {
        placaTextBox.BorderBrush = _corPadrao;
        placaTextBox.BorderThickness = _bordaPadrao;
        placaInvalidaTextBlock.Visibility = _visibilidadepadrao;

        modeloTextBox.BorderBrush = _corPadrao;
        modeloTextBox.BorderThickness = _bordaPadrao;
        modeloInvalidoTextBlock.Visibility = _visibilidadepadrao;

        corTextBox.BorderBrush = _corPadrao;
        corTextBox.BorderThickness = _bordaPadrao;
        corInvalidaTextBlock.Visibility = _visibilidadepadrao;

        marcaTextBox.BorderBrush = _corPadrao;
        marcaTextBox.BorderThickness = _bordaPadrao;
        marcaInvalidaTextBlock.Visibility = _visibilidadepadrao;

        anoTextBox.BorderBrush = _corPadrao;
        anoTextBox.BorderThickness = _bordaPadrao;
        anoInvalidoTextBlock.Visibility = _visibilidadepadrao;
    }

    private bool ValidarCamposFormulario()
    {
        bool camposValidos = true;
        if(string.IsNullOrWhiteSpace(placaTextBox.Text))
        {
            placaTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            placaTextBox.BorderThickness = new Thickness(2);
            placaInvalidaTextBlock.Visibility = Visibility.Visible;
            camposValidos = false;
        }

        if (string.IsNullOrWhiteSpace(modeloTextBox.Text))
        {
            modeloTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            modeloTextBox.BorderThickness = new Thickness(2);
            modeloInvalidoTextBlock.Visibility = Visibility.Visible;
            camposValidos = false;
        }

        if (string.IsNullOrWhiteSpace(corTextBox.Text))
        {
            corTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            corTextBox.BorderThickness = new Thickness(2);
            corInvalidaTextBlock.Visibility = Visibility.Visible;
            camposValidos = false;
        }

        if (string.IsNullOrWhiteSpace(marcaTextBox.Text))
        {
            marcaTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            marcaTextBox.BorderThickness = new Thickness(2);
            marcaInvalidaTextBlock.Visibility = Visibility.Visible;
            camposValidos = false;
        }

        if (string.IsNullOrWhiteSpace(anoTextBox.Text))
        {
            anoTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            anoTextBox.BorderThickness = new Thickness(2);
            anoInvalidoTextBlock.Visibility = Visibility.Visible;
            camposValidos = false;
        }

        return camposValidos;

    }

    private void PlacaVeiculoComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        

        if(placaVeiculoComboBox.SelectedItem is Veiculo veiculo)
        {
            dadosPlacaTextblock.Text = veiculo.Placa;
            dadosPlacaTextblock.Visibility = Visibility.Visible;
            dadosMarcaTextBlock.Text = veiculo.Marca;
            dadosMarcaTextBlock.Visibility = Visibility.Visible;
            dadosModeloTextBlock.Text = veiculo.Modelo;
            dadosModeloTextBlock.Visibility = Visibility.Visible;
        }
    }

    private void CadastrarVeiculo_ButtonClick(object sender, RoutedEventArgs e)
    {
        entradaGrid.Visibility = Visibility.Collapsed;
        cadastroGrid.Visibility = Visibility.Visible;
    }

    private void CadastrarVeiculo_MouseButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        entradaGrid.Visibility = Visibility.Collapsed;
        cadastroGrid.Visibility = Visibility.Visible;
    }

    private async void PlacaVeiculoBusca_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        if (placaVeiculoBuscaTextBox.Text.Length >= 3)
        {
            var veiculos = await _veiculoBusiness.ObterPorPlaca(placaVeiculoBuscaTextBox.Text);
            placaVeiculoComboBox.ItemsSource = new List<Veiculo>();
            placaVeiculoComboBox.ItemsSource = veiculos;
            if(veiculos.Count > 0)
                placaVeiculoComboBox.SelectedValue = veiculos[0];
        }
    }

    private void ContinuarEntradaVeiculo_ButtonClick(object sender, RoutedEventArgs e)
    {

    }
}
