using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Componentes;
using TorneSe.EstacionamentoApp.Store;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para SaidaVeiculosView.xam
/// </summary>
public partial class SaidaVeiculosView : UserControl
{
    private readonly VagasStore _vagasStore;
    private readonly IVeiculoBusiness _veiculoBusiness;

    private int _pagina = 1;
    private const int _paginaInicial = 1;
    private int _porPagina = 20;
    private int _totalPaginas = 0;

    private const string _componente = "Saida";

    public SaidaVeiculosView(VagasStore veiculosStore, IVeiculoBusiness veiculoBusiness)
    {
        InitializeComponent();
        _vagasStore = veiculosStore;
        _veiculoBusiness = veiculoBusiness;
        _totalPaginas = (int)Math.Ceiling(_vagasStore.VagasOcupadas.Count / (double)_porPagina);
        MontarComponente();
    }
    private void MontarComponente()
    {
        var vagas = _vagasStore.VagasOcupadas.Skip((_pagina - 1) * _porPagina).Take(_porPagina).ToList();

        vagasControl.Content = new VagasGridControl(vagas, _componente, _veiculoBusiness, _vagasStore);
        vagasControl.Visibility = Visibility.Visible;
        loadingControl.Visibility = Visibility.Collapsed;
        buscaVagaTextBox.IsEnabled = true;
        voltarButton.Visibility = Visibility.Visible;
        proximoButton.Visibility = Visibility.Visible;
    }

    private async void ProximasVagas_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        if (_pagina == _totalPaginas)
        {
            MessageBox.Show("Não há mais vagas a serem carregadas");
            return;
        }

        vagasControl.Visibility = Visibility.Collapsed;
        loadingControl.Visibility = Visibility.Visible;
        buscaVagaTextBox.IsEnabled = false;
        voltarButton.Visibility = Visibility.Hidden;
        proximoButton.Visibility = Visibility.Hidden;

        await Task.Delay(3000);

        _pagina += 1;
        MontarComponente();
    }

    private async void VoltarVagas_ButtonClick(object sender, RoutedEventArgs e)
    {
        if (_pagina is _paginaInicial)
            return;

        vagasControl.Visibility = Visibility.Collapsed;
        loadingControl.Visibility = Visibility.Visible;
        buscaVagaTextBox.IsEnabled = false;
        voltarButton.Visibility = Visibility.Hidden;
        proximoButton.Visibility = Visibility.Hidden;

        await Task.Delay(3000);

        _pagina -= 1;
        MontarComponente();
    }

    private void VagaBuscaTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is not TextBox textBox)
            return;

        var vagas = _vagasStore.VagasOcupadas.Where(v => v.Placa.Contains(textBox.Text)).ToList();

        if (!vagas.Any())
        {
            MessageBox.Show("Não há vagas com a placa informada");
            return;
        }

        vagasControl.Content = new VagasGridControl(vagas, _componente, _veiculoBusiness, _vagasStore);
    }
}
