using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.UI.Store;

namespace TorneSe.EstacionamentoApp.UI.Views;

/// <summary>
/// Lógica interna para LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    public LoginWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Password))
        {
            MessageBox.Show("Usuário e senha são obrigatórios", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var usuarioBusiness = _serviceProvider.GetRequiredService<IUsuarioBusiness>();
        var usuarioStore = _serviceProvider.GetRequiredService<UsuarioStore>();

        var usuario = await usuarioBusiness.ObterUsuario(txtUsername.Text, txtPassword.Password);

        if(usuario is null)
        {
            MessageBox.Show("Usuário ou senha inválidos", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        usuarioStore.DefinirUsuarioSessao(usuario);
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

    }

    private void CancelarButton_Click(object sender, RoutedEventArgs e) 
        => Close();
}
