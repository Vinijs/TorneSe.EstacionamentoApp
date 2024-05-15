using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Business.Exceptions;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Business.Services.Interfaces;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

namespace TorneSe.EstacionamentoApp.Business;

public sealed class UsuarioBusiness : IUsuarioBusiness
{
    private readonly IUsuarioDAO _usuarioDAO;
    private readonly ICriptografiaService _criptografiaService;
    private readonly IValidator<Usuario> _validator;

    public UsuarioBusiness(IUsuarioDAO usuarioDAO, 
                           ICriptografiaService criptografiaService,
                           IValidator<Usuario> validator)
    {
        _usuarioDAO = usuarioDAO;
        _criptografiaService = criptografiaService;
        _validator = validator;
    }

    public async Task AtualizarUsuario(Usuario usuario)
    {
        ValidarUsuario(usuario);

        var senhaUsuario = await _usuarioDAO.ObterHashSenhaUsuario(usuario.Login);

        if (!string.IsNullOrWhiteSpace(senhaUsuario) && senhaUsuario != usuario.Senha)
            usuario.Senha = _criptografiaService.CalcularMD5Hash(usuario.Senha);

        await _usuarioDAO.Atualizar(usuario);
    }

    private void ValidarUsuario(Usuario usuario)
    {
        var resultadoValidacao = _validator.Validate(usuario);

        if (!resultadoValidacao.IsValid)
            throw new BusinessException(resultadoValidacao.ToString());
    }

    public async Task CadastrarUsuario(Usuario usuario)
    {
        ValidarUsuario(usuario);

        usuario.Senha = _criptografiaService.CalcularMD5Hash(usuario.Senha);
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
