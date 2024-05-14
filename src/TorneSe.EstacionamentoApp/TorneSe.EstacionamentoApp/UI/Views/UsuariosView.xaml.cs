using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Views;

public partial class UsuariosView : UserControl
{
    private ObservableCollection<Usuario> _usuarios;
    private IUsuarioBusiness _usuarioBusiness;

    public UsuariosView(IUsuarioBusiness usuarioBusiness)
    {
        InitializeComponent();
        _usuarios = new ObservableCollection<Usuario>
        {
            new Usuario { Id = 1, Nome = "John", Ativo = true, Email = "john@example.com", DataCadastro = DateTime.Now, Login = "Joe", TipoUsuario = Core.Enums.TipoUsuario.Administrador, PathFoto = "c://Usuarios" },

            new Usuario { Id = 2, Nome = "Jane", Ativo = true, Email = "jane@example.com", DataCadastro = DateTime.Now, Login = "Jan", TipoUsuario = Core.Enums.TipoUsuario.Operador, PathFoto = "c://Documentos"}
        };
        dgUsers.ItemsSource = _usuarios;
        _usuarioBusiness = usuarioBusiness;
    }

    private async void NovoUsuario_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        Usuario usuario = new() { Id = 1, Nome = "John", Ativo = true, Email = "john@example.com", DataCadastro = DateTime.Now, Login = "Joe", TipoUsuario = Core.Enums.TipoUsuario.Administrador, PathFoto = "c://Usuarios" };
        _usuarios.Add(usuario);
        await _usuarioBusiness.CadastrarUsuario(usuario);
        dgUsers.SelectedItem = usuario;
    }

    private async void EditarUsuario_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        Usuario usuarioSelecionado = dgUsers.SelectedItem as Usuario;

        if(usuarioSelecionado is not null)
        {
            await _usuarioBusiness.AtualizarUsuario(usuarioSelecionado); 
        }
    }

    private async void DeletarUsuario_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        Usuario usuarioSelecionado = dgUsers.SelectedItem as Usuario;

        if(usuarioSelecionado is not null)
        {
            await _usuarioBusiness.ExcluirUsuario(usuarioSelecionado); 
            _usuarios.Remove(usuarioSelecionado);
        }
    }
}
