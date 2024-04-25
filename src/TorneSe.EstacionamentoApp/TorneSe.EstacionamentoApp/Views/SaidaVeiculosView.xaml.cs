using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Store;

namespace TorneSe.EstacionamentoApp.Views
{
    /// <summary>
    /// Interação lógica para SaidaVeiculosView.xam
    /// </summary>
    public partial class SaidaVeiculosView : UserControl
    {
        public SaidaVeiculosView(VeiculosStore veiculosStore)
        {
            InitializeComponent();
        }
    }
}
