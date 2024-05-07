using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Configs;

namespace TorneSe.EstacionamentoApp.UI.Extensions;

public static class AddOptionsHosBuilderExtensions
{
    public static IHostBuilder AddOptions(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((hostContext, services) =>
        {
            services.AddOptions<ConfiguracoesAplicacao>()
            .Bind(hostContext.Configuration.GetSection("ConfiguracoesAplicacao"));
        });
        return hostBuilder;
    }
}
