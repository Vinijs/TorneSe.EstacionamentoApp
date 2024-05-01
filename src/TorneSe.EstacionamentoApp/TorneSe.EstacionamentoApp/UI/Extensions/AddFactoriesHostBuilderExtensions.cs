using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Factories;
using TorneSe.EstacionamentoApp.Factories.Interfaces;
using TorneSe.EstacionamentoApp.Views;

namespace TorneSe.EstacionamentoApp.Extensions;

public static class AddFactoriesHostBuilderExtensions
{
    public static IHostBuilder AddFactories(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<IViewFactory, ViewFactory>();
        });
        return hostBuilder;
    }
}
