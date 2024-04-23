using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Enums;
using TorneSe.EstacionamentoApp.Factories.Interfaces;
using TorneSe.EstacionamentoApp.Views;

namespace TorneSe.EstacionamentoApp.Factories;

public sealed class ViewFactory : IViewFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ViewFactory(IServiceProvider serviceProvider) 
        => _serviceProvider = serviceProvider;

    public UserControl CriarView(Paginas pagina) => pagina switch
    {
        Paginas.Home => _serviceProvider.GetRequiredService<HomeView>(),
        Paginas.EntradaVeiculos => _serviceProvider.GetRequiredService<EntradaVeiculosView>(),
        Paginas.SaidaVeiculos => _serviceProvider.GetRequiredService<SaidaVeiculosView>(),
        Paginas.Relatorios => _serviceProvider.GetRequiredService<RelatoriosView>(),
        Paginas.Usuarios => _serviceProvider.GetRequiredService<UsuariosView>(),
        Paginas.Configuracoes => _serviceProvider.GetRequiredService<ConfiguracoesView>(),
        _ => throw new NotImplementedException()
    };
}
