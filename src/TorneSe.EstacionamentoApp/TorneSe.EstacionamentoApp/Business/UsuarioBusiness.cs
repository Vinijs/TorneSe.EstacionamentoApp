using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Business.Services.Interfaces;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

namespace TorneSe.EstacionamentoApp.Business;

public sealed class UsuarioBusiness : IUsuarioBusiness
{
    private readonly IUsuarioDAO _usuarioDAO;
    private readonly ICriptografiaService _criptografiaService;

    public UsuarioBusiness(IUsuarioDAO usuarioDAO, ICriptografiaService criptografiaService)
    {
        _usuarioDAO = usuarioDAO;
        _criptografiaService = criptografiaService;
    }

    public async Task<Usuario?> ObterUsuario(string username, string password)
    {
        var usuario = await _usuarioDAO.ObterPorLogin(username);

        if(usuario is null)
            return null;

        if (!_criptografiaService.CompararHashs(password, usuario.Senha))
            return null;

        return usuario;
    }
}
