using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Enums;
using TorneSe.EstacionamentoApp.Factories.Interfaces;
using TorneSe.EstacionamentoApp.UI.Store;
using TorneSe.EstacionamentoApp.UI.Views;

namespace TorneSe.EstacionamentoApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IViewFactory _viewFactory;
    private readonly UsuarioStore _usuarioStore;

    private const string _pathFotoPadrao = "../Recursos/tornese.png";
    private const string _nomeUsuarioPadrao = "Admin";
    public MainWindow(IViewFactory viewFactory, UsuarioStore usuarioStore)
    {
        InitializeComponent();
        _viewFactory = viewFactory;
        contentControl.Content = _viewFactory.CriarView(Paginas.Home);
        _usuarioStore = usuarioStore;
        MontarComponente();
    }

    private void MontarComponente()
    {
        Usuario usuario = _usuarioStore.ObterUsuarioSessao();
        string pathFoto = usuario?.PathFoto ?? _pathFotoPadrao;
        string nomeUsuario = usuario?.Login ?? _nomeUsuarioPadrao;

        avatarImage.Source = new BitmapImage(new Uri(pathFoto, UriKind.RelativeOrAbsolute));
        usuarioNomeTextBlock.Text = nomeUsuario;
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

    private void MainWindow_Loaded(object sender, RoutedEventArgs e) 
        => Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();
}
