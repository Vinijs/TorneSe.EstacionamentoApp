using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using TorneSe.EstacionamentoApp.Data.Entidades;
using TorneSe.EstacionamentoApp.Store;
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
    private readonly VagasStore _store;
    private readonly int _idVaga;

    private Veiculo? _veiculo;

    public VagaVeiculoEntradaDialog(IVeiculoBusiness veiculoBusiness, int idVaga, VagasStore store)
    {
        InitializeComponent();
        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        _bordaPadrao = placaTextBox.BorderThickness;
        _corPadrao = corTextBox.BorderBrush;
        _visibilidadepadrao = placaInvalidaTextBlock.Visibility;
        _veiculoBusiness = veiculoBusiness;
        _idVaga = idVaga;
        _store = store;
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
            _veiculo = new Veiculo
            {
                Placa = placaTextBox.Text,
                Modelo = modeloTextBox.Text,
                Cor = corTextBox.Text,
                Marca = marcaTextBox.Text,
                Ano = anoTextBox.Text
            };
            cadastroGrid.Visibility = Visibility.Collapsed;
            confirmarGrid.Visibility = Visibility.Visible;
            PreencherDadosVeiculo();
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

    private bool ValidarCamposCondutor()
    {
        bool camposValidos = true;

        if (string.IsNullOrWhiteSpace(nomeCondutorTextBox.Text))
        {
            nomeCondutorTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            nomeCondutorTextBox.BorderThickness = new Thickness(2);
            nomeCondutorInvalidoTextBlock.Visibility = Visibility.Visible;
            camposValidos = false;
        }

        if (string.IsNullOrWhiteSpace(documentoTextBox.Text))
        {
            documentoTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            documentoTextBox.BorderThickness = new Thickness(2);
            documentoInvalidoTextBlock.Visibility = Visibility.Visible;
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

    private async void PlacaVeiculoBusca_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        if (placaVeiculoBuscaTextBox.Text.Length >= 3)
        {
            var veiculos = await _veiculoBusiness.ObterPorPlaca(placaVeiculoBuscaTextBox.Text);
            
            if(veiculos.Count > 0)
            {
                placaVeiculoComboBox.ItemsSource = new List<Veiculo>(veiculos);
                placaVeiculoComboBox.SelectedValue = veiculos
                    .Where(v => v.Placa.Contains(placaVeiculoBuscaTextBox.Text)).FirstOrDefault()
                    ?? veiculos[0];
                _veiculo = (Veiculo)placaVeiculoComboBox.SelectedValue;
            }
            else
            {
                placaVeiculoComboBox.ItemsSource = new List<Veiculo>();
                placaVeiculoComboBox.SelectedValue = null;
                _veiculo = null!;
            }
                
        }
    }

    private void ContinuarEntradaVeiculo_ButtonClick(object sender, RoutedEventArgs e)
    {
        if(_veiculo is not null)
        {
            entradaGrid.Visibility = Visibility.Collapsed;
            confirmarGrid.Visibility = Visibility.Visible;
            PreencherDadosVeiculo();
            
        }
    }

    private void PreencherDadosVeiculo()
    {
        placaInfoTextBlock.Text = _veiculo?.Placa;
        modeloInfoTextBlock.Text = _veiculo?.Modelo;
        marcaInfoTextBlock.Text = _veiculo?.Marca;
        corInfoTextBlock.Text = _veiculo?.Cor;
        anoInfoTextBlock.Text = _veiculo?.Ano;
    }

    private async void ConfirmarDados_Click(object sender, RoutedEventArgs e)
    {
        var camposValido = ValidarCamposCondutor();

        if (camposValido)
        {
            await _veiculoBusiness.RealizarEntradaVeiculo(_veiculo!, _idVaga, nomeCondutorTextBox.Text, documentoTextBox.Text);
            _store.OcuparVaga(_idVaga);
            GerarTicketEntrada();
            Close();
        }
    }

    private void GerarTicketEntrada()
        {
            // Crie uma instância da classe PrintDialog
            PrintDialog printDialog = new();

            if (printDialog.ShowDialog() == true)
            {
                // Configurar o conteúdo a ser impresso
                FixedDocument document = new();
                PageContent pageContent = new();
                FixedPage fixedPage = new();

                // Obter a data e hora atual
                DateTime dataHoraAtual = DateTime.Now;

                //Campos do ticket
                TextBlock textBlockTitulo = new()
                {
                    Text = $"Ticket de Entrada - Data e Hora: {dataHoraAtual.ToString("dd/MM/yyyy HH:mm:ss")}",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold
                };
                FixedPage.SetLeft(textBlockTitulo, 10);
                FixedPage.SetTop(textBlockTitulo, 0);
                fixedPage.Children.Add(textBlockTitulo);

                TextBlock dadosVeiculosTextBlock = new()
                {
                    Text = "Dados do Veículo",
                    FontSize = 16,
                    FontWeight = FontWeights.Bold
                };
                FixedPage.SetLeft(dadosVeiculosTextBlock, 10);
                FixedPage.SetTop(dadosVeiculosTextBlock, 40);
                fixedPage.Children.Add(dadosVeiculosTextBlock);

                TextBlock textBlockPlaca = new()
                {
                    Text = "Placa: " + placaInfoTextBlock.Text,
                    FontSize = 14
                };
                FixedPage.SetLeft(textBlockPlaca, 10);
                FixedPage.SetTop(textBlockPlaca, 100);
                fixedPage.Children.Add(textBlockPlaca);

                TextBlock textBlockModelo = new()
                {
                    Text = "Modelo: " + modeloInfoTextBlock.Text,
                    FontSize = 14
                };
                FixedPage.SetLeft(textBlockModelo, 10);
                FixedPage.SetTop(textBlockModelo, 120);
                fixedPage.Children.Add(textBlockModelo);

                TextBlock textBlockMarca = new()
                {
                    Text = "Marca: " + marcaInfoTextBlock.Text,
                    FontSize = 14
                };
                FixedPage.SetLeft(textBlockMarca, 10);
                FixedPage.SetTop(textBlockMarca, 140);
                fixedPage.Children.Add(textBlockMarca);

                TextBlock textBlockCor = new()
                {
                    Text = "Cor: " + corInfoTextBlock.Text,
                    FontSize = 14
                };
                FixedPage.SetLeft(textBlockCor, 10);
                FixedPage.SetTop(textBlockCor, 160);
                fixedPage.Children.Add(textBlockCor);

                TextBlock textBlockAno = new()
                {
                    Text = "Ano: " + anoInfoTextBlock.Text,
                    FontSize = 14
                };
                FixedPage.SetLeft(textBlockAno, 10);
                FixedPage.SetTop(textBlockAno, 180);
                fixedPage.Children.Add(textBlockAno);

                // Adicionar a página fixa ao documento
                ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
                document.Pages.Add(pageContent);

                // Definir o tamanho do papel
                printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA7);
                printDialog.PrintTicket.OutputColor = OutputColor.Monochrome;
                printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
                printDialog.PrintTicket.PageBorderless = PageBorderless.None;

                // Imprimir o conteúdo
                printDialog.PrintDocument(document.DocumentPaginator, "Ticket de Estacionamento");
            }
        }
    

    private void CancelarDados_Click(object sender, RoutedEventArgs e) 
        => Cancelar_Click(sender, e);
}
