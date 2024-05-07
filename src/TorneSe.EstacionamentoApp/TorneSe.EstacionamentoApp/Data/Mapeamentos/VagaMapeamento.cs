using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Data.Mapeamentos;

public class VagaMapeamento : IEntityTypeConfiguration<Vaga>
{
    public void Configure(EntityTypeBuilder<Vaga> builder)
    {
        builder.ToTable("Vagas");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .ValueGeneratedOnAdd();

        builder.Property(v => v.Codigo)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(v => v.Ocupada)
            .IsRequired();

        builder.Property(v => v.Numero)
            .IsRequired();

        builder.Property(v => v.Andar)
            .IsRequired();

        builder.HasMany(v => v.Reservas)
            .WithOne(r => r.Vaga)
            .HasForeignKey(r => r.IdVaga)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(v => v.Veiculo)
            .WithOne(v => v.Vaga)
            .HasForeignKey<Vaga>(v => v.IdVeiculo)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
