using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Data.DAO;
using TorneSe.EstacionamentoApp.Data.DAO.Interfaces;

namespace TorneSe.EstacionamentoApp.UI.Extensions;

public static class AddDatabaseHostBuilderExtensions
{
    public static IHostBuilder AddDatabase(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((hostContext, services) =>
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dbPath = Path.Combine(path, "estacionamento.db");

            if (!File.Exists(dbPath))
            {
                using var fileStream = File.Create(dbPath);
            }

            services.AddDbContext<EstacionamentoContexto>(options =>
            {
                options.UseSqlite($"Data Source={dbPath};");
            }, ServiceLifetime.Transient);

            services.AddTransient<EstacionamentoContexto>();

            services.AddTransient<IVeiculoDAO, VeiculoDAO>();
            services.AddTransient<IReservaVagaVeiculoDAO, ReservaVagaVeiculoDAO>();
            services.AddTransient<IVagaDAO, VagaDAO>();
            services.AddTransient<IUsuarioDAO, UsuarioDAO>();
        });
        return hostBuilder;
    }
}
