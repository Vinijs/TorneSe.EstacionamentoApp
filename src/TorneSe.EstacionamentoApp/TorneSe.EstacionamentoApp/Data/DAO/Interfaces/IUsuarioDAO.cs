using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

public interface IUsuarioDAO
{
    Task<Usuario?> ObterPorLogin(string login);
    Task Inserir(Usuario usuario);
    Task Excluir(int id);
    Task<IEnumerable<Usuario>> Listar();
}
