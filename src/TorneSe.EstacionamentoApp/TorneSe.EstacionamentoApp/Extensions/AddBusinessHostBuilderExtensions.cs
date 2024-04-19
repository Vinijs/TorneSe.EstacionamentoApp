using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Business;
using TorneSe.EstacionamentoApp.Business.Interfaces;

namespace TorneSe.EstacionamentoApp.Extensions;

public static class AddBusinessHostBuilderExtensions
{
    public static IHostBuilder AddBusiness(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<IExemploBusiness, ExemploBusiness>();
        });

        return hostBuilder;
    } 
}
