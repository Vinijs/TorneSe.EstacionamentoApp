using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Store;

namespace TorneSe.EstacionamentoApp.Extensions;

public static class AddStoresHostBuilderExtensions
{
    public static IHostBuilder AddStores(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<VagasStore>();
        });
        return hostBuilder;
    }
}
