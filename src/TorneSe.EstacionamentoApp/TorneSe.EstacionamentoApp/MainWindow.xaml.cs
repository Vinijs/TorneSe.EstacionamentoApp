using System;
using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Enums;
using TorneSe.EstacionamentoApp.Factories.Interfaces;

namespace TorneSe.EstacionamentoApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IViewFactory _viewFactory;
    public MainWindow(IViewFactory viewFactory)
    {
        InitializeComponent();
        _viewFactory = viewFactory;
        contentControl.Content = _viewFactory.CriarView(Paginas.Home);
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            return;

        var nomeView = (Paginas)Enum.Parse(typeof(Paginas), button.CommandParameter.ToString()!);

        contentControl.Content = _viewFactory.CriarView(nomeView);
    }

    private void FecharAplicacao_Click(object sender, RoutedEventArgs e) 
        => Close();
}
