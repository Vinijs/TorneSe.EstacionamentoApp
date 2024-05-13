using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Business.Interfaces;

public interface IUsuarioBusiness
{
    Task<Usuario?> ObterUsuario(string username, string password);
}
