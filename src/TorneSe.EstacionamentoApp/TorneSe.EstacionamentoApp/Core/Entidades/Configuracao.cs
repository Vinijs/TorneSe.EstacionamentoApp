using System;

namespace TorneSe.EstacionamentoApp.Core.Entidades;

public class Configuracao
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Valor { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string UsuarioUltimaAtualizacao { get; set; } = string.Empty;
}
