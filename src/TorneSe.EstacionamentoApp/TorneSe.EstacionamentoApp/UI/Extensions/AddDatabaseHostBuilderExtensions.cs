using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddTransient<EstacionamentoContexto>();

            services.AddTransient<IVeiculoDAO, VeiculoDAO>();
            services.AddTransient<IReservaVagaVeiculoDAO, ReservaVagaVeiculoDAO>();
            services.AddTransient<IVagaDAO, VagaDAO>();
        });
        return hostBuilder;
    }
}
