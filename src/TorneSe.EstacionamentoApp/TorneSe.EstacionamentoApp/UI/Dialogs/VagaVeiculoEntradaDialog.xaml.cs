using System;
using System.Windows;
using System.Windows.Media;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Dialogs;

/// <summary>
/// Lógica interna para VagaVeiculoDialog.xaml
/// </summary>
public partial class VagaVeiculoEntradaDialog : Window
{
    private readonly Thickness _bordaPadrao;
    private readonly Brush _corPadrao;
    private readonly Visibility _visibilidadepadrao;

    public VagaVeiculoEntradaDialog()
    {
        InitializeComponent();
        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        _bordaPadrao = placaTextBox.BorderThickness;
        _corPadrao = corTextBox.BorderBrush;
        _visibilidadepadrao = placaInvalidaTextBlock.Visibility;
        placaVeiculoComboBox.ItemsSource = new Veiculo[] {
            new Veiculo { Id = 1, Placa = "ABC-1234", Modelo = "Fiat", Marca = "Uno", Ano = "2020" },
            new Veiculo { Id = 2, Placa = "DEF-5678", Modelo = "Fiat", Marca = "Palio", Ano = "2020" },
            new Veiculo { Id = 3, Placa = "GHI-9012", Modelo = "Fiat", Marca = "Mobi", Ano = "2022" },
        };
    }

    private void Cancelar_Click(object sender, RoutedEventArgs e) 
        => Close();

    private void Confirmar_Click(object sender, RoutedEventArgs e)
    {
        LimparFormatacaoErros();
        ValidarCamposFormulario();
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

    private void ValidarCamposFormulario()
    {
        if(string.IsNullOrWhiteSpace(placaTextBox.Text))
        {
            placaTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            placaTextBox.BorderThickness = new Thickness(2);
            placaInvalidaTextBlock.Visibility = Visibility.Visible;
        }

        if (string.IsNullOrWhiteSpace(modeloTextBox.Text))
        {
            modeloTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            modeloTextBox.BorderThickness = new Thickness(2);
            modeloInvalidoTextBlock.Visibility = Visibility.Visible;
        }

        if (string.IsNullOrWhiteSpace(corTextBox.Text))
        {
            corTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            corTextBox.BorderThickness = new Thickness(2);
            corInvalidaTextBlock.Visibility = Visibility.Visible;
        }

        if (string.IsNullOrWhiteSpace(marcaTextBox.Text))
        {
            marcaTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            marcaTextBox.BorderThickness = new Thickness(2);
            marcaInvalidaTextBlock.Visibility = Visibility.Visible;
        }

        if (string.IsNullOrWhiteSpace(anoTextBox.Text))
        {
            anoTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            anoTextBox.BorderThickness = new Thickness(2);
            anoInvalidoTextBlock.Visibility = Visibility.Visible;
        }

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

    }
}
