using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TorneSe.EstacionamentoApp.Dialogs;

namespace TorneSe.EstacionamentoApp.Controls;

/// <summary>
/// Interação lógica para VagaVeiculoCardControl.xam
/// </summary>
public partial class VagaVeiculoCardControl : UserControl
{
    private string CorBordaCard { get; set; }
    public string DonoComponente { get; set; }

    public VagaVeiculoCardControl()
    {
        InitializeComponent();
        CorBordaCard = "Green";
        DonoComponente = "Entrada";
    }

    private void MouseClick_Event(object sender, MouseButtonEventArgs e)
    {
        if(DonoComponente is "Saida")
        {
            var dialogSaida = new VagaVeiculoSaidaDialog();
            dialogSaida.ShowDialog();
        }
        else
        {
            var dialogEntrada = new VagaVeiculoEntradaDialog();
            dialogEntrada.ShowDialog();
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
