using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.UI.Dialogs;

namespace TorneSe.EstacionamentoApp.Views;

public partial class UsuariosView : UserControl
{
    private ObservableCollection<Usuario> _usuarios;
    private IUsuarioBusiness _usuarioBusiness;
    private UsuarioInfoDialog _usuarioInfoDialog;

    public UsuariosView(IUsuarioBusiness usuarioBusiness)
    {
        _usuarioBusiness = usuarioBusiness;
        InitializeComponent();
        MontarComponente();
        dgUsers.ItemsSource = _usuarios;
    }

    private async void MontarComponente() 
        => _usuarios = new ObservableCollection<Usuario>(await _usuarioBusiness.ObterUsuarios());

    private async void NovoUsuario_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        try
        {
            _usuarioInfoDialog = new UsuarioInfoDialog();

            if (_usuarioInfoDialog.ShowDialog() is true)
            {
                _usuarios.Add(_usuarioInfoDialog.Usuario!);
                await _usuarioBusiness.CadastrarUsuario(_usuarioInfoDialog.Usuario!);
                dgUsers.SelectedItem = _usuarioInfoDialog.Usuario;
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private async void EditarUsuario_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        try
        {
            Usuario usuarioSelecionado = dgUsers.SelectedItem as Usuario;

            if (usuarioSelecionado is not null)
            {
                _usuarioInfoDialog = new UsuarioInfoDialog(usuarioSelecionado);

                if (_usuarioInfoDialog.ShowDialog() is true)
                {
                    await _usuarioBusiness.AtualizarUsuario(usuarioSelecionado);
                    MontarComponente();
                }
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void DeletarUsuario_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        Usuario usuarioSelecionado = dgUsers.SelectedItem as Usuario;

        if(usuarioSelecionado is not null)
        {
            await _usuarioBusiness.ExcluirUsuario(usuarioSelecionado); 
            MontarComponente();
        }
    }
}
