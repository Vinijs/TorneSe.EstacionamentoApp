using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Business.Interfaces;

public interface IUsuarioBusiness
{
    Task<Usuario?> ObterUsuario(string username, string password);
    Task CadastrarUsuario(Usuario usuario);
    Task AtualizarUsuario(Usuario usuario);
    Task ExcluirUsuario(Usuario usuario);
    Task<List<Usuario>> ObterUsuarios();
}
