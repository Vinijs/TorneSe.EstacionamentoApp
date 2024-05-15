using System.Windows;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.UI.Helpers;

namespace TorneSe.EstacionamentoApp.UI.Dialogs;

public partial class UsuarioInfoDialog : Window
{
    public Usuario? Usuario;

    public UsuarioInfoDialog(Usuario? usuario = null)
    {
        InitializeComponent();
        Usuario = usuario;
        MontarComponente();
    }

    private void MontarComponente()
    {
        if(Usuario is not null)
        {
            nomeTextBox.Text = Usuario.Nome;
            loginTextBox.Text = Usuario.Login;
            emailTextBox.Text = Usuario.Email;
            _ = (Usuario.TipoUsuario == Core.Enums.TipoUsuario.Administrador)
                ? adminCheckBox.IsChecked = true
                : operadorCheckBox.IsChecked = true;

            ativoCheckBox.IsChecked = Usuario.Ativo;
            senhaTextBox.Text = Usuario.Senha;
            fotoTextBox.Text = Usuario.PathFoto;
        }
    }

    private void Save_ButttonClick(object sender, RoutedEventArgs e)
    {
        Usuario ??= new Usuario();

        Usuario.Nome = nomeTextBox.Text;
        Usuario.Login = loginTextBox.Text;
        Usuario.Email = emailTextBox.Text;
        Usuario.TipoUsuario = (adminCheckBox.IsChecked == true)
            ? Core.Enums.TipoUsuario.Administrador
            : Core.Enums.TipoUsuario.Operador;
        Usuario.Ativo = ativoCheckBox.IsChecked == true;
        Usuario.Senha = senhaTextBox.Text;
        Usuario.PathFoto = fotoTextBox.Text;
        DialogResult = true;
        Close();
    }

    private void Cancel_ButtonClick(object sender, RoutedEventArgs e) 
        => Close();

    private void BuscarArquivo_ButtonClick(object sender, RoutedEventArgs e)
    {
        var pathArquivo = DialogHelper.ObterPathImagemAvatarUsuario();

        if (!string.IsNullOrWhiteSpace(pathArquivo))
            fotoTextBox.Text = pathArquivo;
    }
}
