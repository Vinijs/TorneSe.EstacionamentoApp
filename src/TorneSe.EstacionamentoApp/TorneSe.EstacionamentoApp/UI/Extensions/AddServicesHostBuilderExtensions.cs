using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Business.Services;
using TorneSe.EstacionamentoApp.Business.Services.Interfaces;

namespace TorneSe.EstacionamentoApp.UI.Extensions;

public static class AddServicesHostBuilderExtensions
{
    public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<ICriptografiaService, CriptografiaService>();
        });

        return hostBuilder;
    }
}
