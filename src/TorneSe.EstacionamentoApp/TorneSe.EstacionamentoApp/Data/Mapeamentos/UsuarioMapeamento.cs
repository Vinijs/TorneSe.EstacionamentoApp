using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Data.Mapeamentos;

public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Login)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.TipoUsuario)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Ativo)
            .IsRequired();

        builder.Property(x => x.DataCadastro)
            .IsRequired();

        builder.Property(x => x.PathFoto)
            .IsRequired(false)
            .HasMaxLength(400);
    }
}
