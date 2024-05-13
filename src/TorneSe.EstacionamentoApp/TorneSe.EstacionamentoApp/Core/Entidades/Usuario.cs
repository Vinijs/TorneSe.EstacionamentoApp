using System;
using TorneSe.EstacionamentoApp.Core.Enums;

namespace TorneSe.EstacionamentoApp.Core.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string Email { get; set; } = null!;
    public TipoUsuario TipoUsuario { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}
