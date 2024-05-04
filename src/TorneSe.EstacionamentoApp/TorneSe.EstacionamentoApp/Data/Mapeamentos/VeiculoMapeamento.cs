using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.Mapeamentos;

public class VeiculoMapeamento : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("Veiculos");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .ValueGeneratedOnAdd();

        builder.Property(v => v.Placa)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(v => v.Marca)
           .HasMaxLength(50)
           .IsRequired();

        builder.Property(v => v.Modelo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.Cor)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(v => v.Ano)
            .HasMaxLength(4)
            .IsRequired();
    }
}
