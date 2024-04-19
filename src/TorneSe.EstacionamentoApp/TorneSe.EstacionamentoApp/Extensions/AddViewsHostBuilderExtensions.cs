using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TorneSe.EstacionamentoApp.Extensions;
public static class AddViewsHostBuilderExtensions
{
    public static IHostBuilder AddViews(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindow>();
        });
        return hostBuilder;
    } 
}
