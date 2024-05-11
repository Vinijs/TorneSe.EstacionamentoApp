using System.Windows;

namespace TorneSe.EstacionamentoApp.UI.Views;

/// <summary>
/// Lógica interna para LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CancelarButton_Click(object sender, RoutedEventArgs e) 
        => Close();
}
