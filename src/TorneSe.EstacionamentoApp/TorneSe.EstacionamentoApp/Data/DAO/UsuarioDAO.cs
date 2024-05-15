using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneSe.EstacionamentoApp.Core.Entidades;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

namespace TorneSe.EstacionamentoApp.Data.DAO;

public class UsuarioDAO : IUsuarioDAO
{
    private readonly EstacionamentoContexto _contexto;

    public UsuarioDAO(EstacionamentoContexto contexto) 
        => _contexto = contexto;

    public async Task Atualizar(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task Excluir(int id)
    {
        var usuario = await _contexto.Usuarios.FindAsync(id);

        if (usuario == null)
            return;

        _contexto.Usuarios.Remove(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task Inserir(Usuario usuario)
    {
        await _contexto.Usuarios.AddAsync(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<Usuario>> Listar() 
        => await _contexto.Usuarios.ToListAsync();

    public async Task<Usuario> ObterPorLogin(string login) 
        => await _contexto.Usuarios
            .FirstOrDefaultAsync(x => x.Login == login || x.Email == login);

    public async Task<string> ObterHashSenhaUsuario(string login) 
        => await _contexto.Usuarios
            .Where(x => x.Login == login || x.Email == login)
            .Select(x => x.Senha)
            .FirstOrDefaultAsync();
}
