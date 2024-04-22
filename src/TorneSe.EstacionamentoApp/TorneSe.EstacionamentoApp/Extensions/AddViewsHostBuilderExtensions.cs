using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.ViewModels;

namespace TorneSe.EstacionamentoApp.Extensions;
public static class AddViewsHostBuilderExtensions
{
    public static IHostBuilder AddViews(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton(s =>
            {
                var business = s.GetRequiredService<IExemploBusiness>();
                var main = new MainWindow(business)
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                };
                return main;
            });
        });
        return hostBuilder;
    } 
}
