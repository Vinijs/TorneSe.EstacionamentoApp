using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Data.Mapeamentos;

public class ReservaVagaVeiculoMapeamento : IEntityTypeConfiguration<ReservaVagaVeiculo>
{
    public void Configure(EntityTypeBuilder<ReservaVagaVeiculo> builder)
    {
        builder.ToTable("ReservaVagaVeiculo");

        builder.HasKey(rv => rv.Id);

        builder.Property(rv => rv.Id)
            .ValueGeneratedOnAdd();

        builder.Property(rv => rv.HoraEntrada)
            .IsRequired();

        builder.Property(rv => rv.HoraSaida)
            .IsRequired(false);

        builder.Property(rv => rv.HorasUtilizadas)
            .HasPrecision(10, 2)
            .IsRequired(false);

        builder.Property(rv => rv.ValorCobrado)
            .HasPrecision(10, 2)
            .IsRequired(false);

        builder.Property(rv => rv.NomeCondutor)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(rv => rv.DocumentoCondutor)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(rv => rv.Vaga)
            .WithMany(v => v.Reservas)
            .HasForeignKey(rv => rv.IdVaga);

        builder.HasOne(rv => rv.Veiculo)
            .WithMany(v => v.Reservas)
            .HasForeignKey(rv => rv.IdVeiculo);
    }
}
