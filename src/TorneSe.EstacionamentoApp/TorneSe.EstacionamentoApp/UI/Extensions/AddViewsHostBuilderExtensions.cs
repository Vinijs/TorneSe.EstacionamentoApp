using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.UI.Views;
using TorneSe.EstacionamentoApp.Views;

namespace TorneSe.EstacionamentoApp.Extensions;
public static class AddViewsHostBuilderExtensions
{
    public static IHostBuilder AddViews(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<LoginWindow>();

            services.AddTransient<HomeView>();
            services.AddTransient<ConfiguracoesView>();
            services.AddTransient<EntradaVeiculosView>();
            services.AddTransient<SaidaVeiculosView>();
            services.AddTransient<RelatoriosView>();
            services.AddTransient<UsuariosView>();
        });
        return hostBuilder;
    } 
}
