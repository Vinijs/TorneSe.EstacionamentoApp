using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.UI.Store;
public sealed class UsuarioStore
{
    private Usuario? _usuario;

    public void DefinirUsuarioSessao(Usuario usuario) 
        => _usuario = usuario;

    public Usuario? ObterUsuarioSessao() 
        => _usuario;
}
