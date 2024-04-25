using System;
using System.Linq;
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
    private double _totalPaginas = 0;


    private const string _componente = "Entrada";

    public EntradaVeiculosView(VeiculosStore veiculosStore)
    {
        InitializeComponent();
        _veiculosStore = veiculosStore;
        _totalPaginas = Math.Ceiling((double)(_veiculosStore.VagasLivres.Count / _porPagina));
        MontarComponente();
    }

    private void MontarComponente()
    {
        var vagas = _veiculosStore.VagasLivres.Skip((_pagina - 1) * _porPagina).Take(_porPagina).ToList();

        vagasControl.Content = new VagasGridControl(vagas, _componente);
        
    }

    private void ProximasVagas_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        if (_pagina == _totalPaginas)
        {
            MessageBox.Show("Não há mais vagas a serem carregadas");
            return;
        }
            

        _pagina += 1;
        MontarComponente();
    }

    private void VoltarVagas_ButtonClick(object sender, RoutedEventArgs e)
    {
        if(_pagina is _paginaInicial)
            return;

        _pagina -= 1;
        MontarComponente();
    }
}
