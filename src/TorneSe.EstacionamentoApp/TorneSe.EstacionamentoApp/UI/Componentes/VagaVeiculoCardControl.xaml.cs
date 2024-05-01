using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TorneSe.EstacionamentoApp.Data.Dtos;
using TorneSe.EstacionamentoApp.Dialogs;

namespace TorneSe.EstacionamentoApp.Controls;

/// <summary>
/// Interação lógica para VagaVeiculoCardControl.xam
/// </summary>
public partial class VagaVeiculoCardControl : UserControl
{
    private string CorBordaCard { get; set; }
    public string DonoComponente { get; set; }
    private VagaVeiculoEntradaDialog _dialogEntrada;
    private VagaVeiculoSaidaDialog _dialogSaida;

    public VagaVeiculoCardControl(ResumoVaga resumoVaga)
    {
        InitializeComponent();
        CorBordaCard = "Green";
        DonoComponente = "Entrada";
        vagaNomeTextBlock.Text = resumoVaga.NomeVaga;
        placaTextblock.Text = resumoVaga.Placa;
        proprietarioTextblock.Text = resumoVaga.ModeloMarca;
        _dialogEntrada = new VagaVeiculoEntradaDialog();
        _dialogSaida = new VagaVeiculoSaidaDialog();
    }

    private void MouseClick_Event(object sender, MouseButtonEventArgs e)
    {
        if(DonoComponente is "Saida")
        {
            _dialogSaida.ShowDialog();
        }
        else
        {
            _dialogEntrada.ShowDialog();
        }
    }

    private void CardControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        if(DonoComponente is "Saida")
        {
            CorBordaCard = "Red";
            cardBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(CorBordaCard));
            placaTextblock.Visibility = System.Windows.Visibility.Visible;
            proprietarioTextblock.Visibility = System.Windows.Visibility.Visible;
        }
        else
        {
            cardBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(CorBordaCard));
            placaTextblock.Visibility = System.Windows.Visibility.Collapsed;
            proprietarioTextblock.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
