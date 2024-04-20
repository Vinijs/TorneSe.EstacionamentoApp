using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Views;

namespace TorneSe.EstacionamentoApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IExemploBusiness _business;
    public MainWindow(IExemploBusiness business)
    {
        InitializeComponent();
        contentControl.Content = new HomeView();
        _business = business;
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;

        if (button is null)
            return;

        UserControl view = button.Name switch 
        {
            "Home" => new HomeView(),
            "EntradaVeiculos" => new EntradaVeiculosView(),
            "SaidaVeiculos" => new SaidaVeiculosView(),
            "Relatorios" => new RelatoriosView(),
            "Usuarios" => new UsuariosView(),
            "Configuracoes" => new ConfiguracoesView()
        };

        contentControl.Content = view;
    }

    private void FecharAplicacao_Click(object sender, RoutedEventArgs e) 
        => Close();
}
