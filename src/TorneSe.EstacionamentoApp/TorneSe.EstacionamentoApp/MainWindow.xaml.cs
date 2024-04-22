using System.Windows;
using TorneSe.EstacionamentoApp.Business.Interfaces;

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
        _business = business;
    }

    private void FecharAplicacao_Click(object sender, RoutedEventArgs e) 
        => Close();
}
