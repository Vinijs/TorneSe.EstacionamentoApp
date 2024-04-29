using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Componentes;
using TorneSe.EstacionamentoApp.Controls;
using TorneSe.EstacionamentoApp.Store;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para EntradaVeiculosView.xam
/// </summary>
public partial class EntradaVeiculosView : UserControl
{
    private readonly VeiculosStore _veiculosStore;
    private int _pagina = 1;
    private const int _paginaInicial = 1;
    private int _porPagina = 20;
    private int _totalPaginas = 0;


    private const string _componente = "Entrada";

    public EntradaVeiculosView(VeiculosStore veiculosStore)
    {
        InitializeComponent();
        _veiculosStore = veiculosStore;
        _totalPaginas = (int)Math.Ceiling(_veiculosStore.VagasLivres.Count / (double)_porPagina);
        MontarComponente();
    }

    private void MontarComponente()
    {
        var vagas = _veiculosStore.VagasLivres.Skip((_pagina - 1) * _porPagina).Take(_porPagina).ToList();

        vagasControl.Content = new VagasGridControl(vagas, _componente);

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

        vagasControl.Content = new LoadingSquareControl();

        buscaVagaTextBox.IsEnabled = false;
        voltarButton.Visibility = Visibility.Hidden;
        proximoButton.Visibility = Visibility.Hidden;

        await Task.Delay(3000);

        _pagina += 1;
        MontarComponente();
    }

    private async void VoltarVagas_ButtonClick(object sender, RoutedEventArgs e)
    {
        if(_pagina is _paginaInicial)
            return;

        vagasControl.Content = new LoadingSquareControl();

        buscaVagaTextBox.IsEnabled = false;
        voltarButton.Visibility = Visibility.Hidden;
        proximoButton.Visibility = Visibility.Hidden;

        await Task.Delay(3000);

        _pagina -= 1;
        MontarComponente();
    }

    private async void VagaBuscaTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is not TextBox textBox)
            return;

        var vagas = _veiculosStore.VagasLivres.Where(v => v.NomeVaga.Contains(textBox.Text)).ToList();

        if (!vagas.Any())
        {
            MessageBox.Show("Não há vagas com esse nome");
            return;
        }

        vagasControl.Content = new VagasGridControl(vagas, _componente);
    }
}
