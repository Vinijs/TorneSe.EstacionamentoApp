using System.Windows.Controls;
using System.Windows.Input;
using TorneSe.EstacionamentoApp.Dialogs;

namespace TorneSe.EstacionamentoApp.Controls;

/// <summary>
/// Interação lógica para VagaVeiculoCardControl.xam
/// </summary>
public partial class VagaVeiculoCardControl : UserControl
{
    public VagaVeiculoCardControl()
    {
        InitializeComponent();
    }

    private void MouseClick_Event(object sender, MouseButtonEventArgs e)
    {
        var dialog = new VagaVeiculoDialog();
        dialog.ShowDialog();
    }
}
