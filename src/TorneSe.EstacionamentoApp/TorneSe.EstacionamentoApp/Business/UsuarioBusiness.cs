using System.Collections.Generic;
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

    public async Task AtualizarUsuario(Usuario usuario)
    {
        await _usuarioDAO.Atualizar(usuario);
    }

    public async Task CadastrarUsuario(Usuario usuario)
    {
        await _usuarioDAO.Inserir(usuario);
    }

    public async Task ExcluirUsuario(Usuario usuario)
    {
        if (!usuario.Ativo)
            return;

        usuario.Ativo = false;
        await _usuarioDAO.Atualizar(usuario);
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

    public async Task<List<Usuario>> ObterUsuarios() 
        => await _usuarioDAO.Listar();
}
