﻿using Microsoft.EntityFrameworkCore;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.Data.Contexto;

public class EstacionamentoContexto : DbContext
{
    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ReservaVagaVeiculo> ReservaVagaVeiculos { get; set; }

    public EstacionamentoContexto(DbContextOptions<EstacionamentoContexto> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstacionamentoContexto).Assembly);
        base.OnModelCreating(modelBuilder);
    }


}
