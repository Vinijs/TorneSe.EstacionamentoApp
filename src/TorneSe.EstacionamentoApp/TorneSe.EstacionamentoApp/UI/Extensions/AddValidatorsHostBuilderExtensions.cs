using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorneSe.EstacionamentoApp.Business.Validadores;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.UI.Extensions;

public static class AddValidatorsHostBuilderExtensions
{
    public static IHostBuilder AddValidators(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient<IValidator<Usuario>, UsuarioValidator>();
        });
    }
}
