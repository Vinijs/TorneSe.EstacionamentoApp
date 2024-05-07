using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Dialogs;
using TorneSe.EstacionamentoApp.Store;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Controls;

/// <summary>
/// Interação lógica para VagaVeiculoCardControl.xam
/// </summary>
public partial class VagaVeiculoCardControl : UserControl
{
    private readonly IVeiculoBusiness _veiculoBusiness;
    private readonly VagasStore _store;
    
    private readonly ResumoVaga _resumoVaga;
    private string CorBordaCard { get; set; }
    public string DonoComponente { get; set; }
    private VagaVeiculoEntradaDialog _dialogEntrada;
    private VagaVeiculoSaidaDialog _dialogSaida;

    public VagaVeiculoCardControl(ResumoVaga resumoVaga, 
                                  IVeiculoBusiness veiculoBusiness,
                                  VagasStore store)
    {
        InitializeComponent();
        CorBordaCard = "Green";
        DonoComponente = "Entrada";
        vagaNomeTextBlock.Text = resumoVaga.NomeVaga;
        placaTextblock.Text = resumoVaga.Placa;
        proprietarioTextblock.Text = resumoVaga.ModeloMarca;
        _veiculoBusiness = veiculoBusiness;
        _resumoVaga = resumoVaga;
        _store = store;
    }

    private void MouseClick_Event(object sender, MouseButtonEventArgs e)
    {
        if (DonoComponente is "Saida")
        {
            _dialogSaida = new VagaVeiculoSaidaDialog(_veiculoBusiness, _store, _resumoVaga);
            _dialogSaida.ShowDialog();
        }
        else
        {
            _dialogEntrada = new VagaVeiculoEntradaDialog(_veiculoBusiness, _resumoVaga.IdVaga, _store);
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
