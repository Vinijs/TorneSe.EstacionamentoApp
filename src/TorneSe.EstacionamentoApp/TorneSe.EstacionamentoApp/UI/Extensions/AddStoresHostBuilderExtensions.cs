using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Data.Contexto;
using TorneSe.EstacionamentoApp.Store;

namespace TorneSe.EstacionamentoApp.Extensions;

public static class AddStoresHostBuilderExtensions
{
    public static IHostBuilder AddStores(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton((services) =>
            {
                const int totalVagasEmMemoria = 40;
                var contexto = services.GetRequiredService<EstacionamentoContexto>();

                var vagasLivres = from va in contexto.Vagas
                                  where va.IdVeiculo == null
                                  select new ResumoVaga(va.Id, $"{va.Codigo}-{va.Id}", null!, null!, default);

                var vagasOcupadas = from va in contexto.Vagas
                                    join ve in contexto.Veiculos on va.IdVeiculo equals ve.Id
                                    where va.IdVeiculo != null
                                    select new ResumoVaga(va.Id, $"{va.Codigo}-{va.Id}",
                                    ve.Placa, $"{ve.Modelo}/{ve.Marca}", ve.Id);

                var store = new VagasStore(vagasLivres.Take(totalVagasEmMemoria).ToList(), 
                            vagasOcupadas.Take(totalVagasEmMemoria).ToList());

                return store;
            });
        });
        return hostBuilder;
    }
}
