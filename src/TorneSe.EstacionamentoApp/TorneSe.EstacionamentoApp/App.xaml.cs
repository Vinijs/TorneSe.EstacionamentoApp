using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Forms = System.Windows.Forms;
using TorneSe.EstacionamentoApp.Extensions;
using System;
using TorneSe.EstacionamentoApp.UI.Extensions;
using TorneSe.EstacionamentoApp.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;
    private Forms.NotifyIcon _notify;
    public App()
    {
        _host = Host
            .CreateDefaultBuilder()
            .AddDatabase()
            .AddStores()
            .AddNotifications()
            .AddBusiness()
            .AddFactories()
            .AddViews()
            .ConfigureHostConfiguration(config =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false);
                config.AddEnvironmentVariables();
            })
            .AddOptions()
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        SeedDatabase();

        _notify = _host.Services.GetRequiredService<Forms.NotifyIcon>();

        //Menus
        _notify.ContextMenuStrip = new Forms.ContextMenuStrip();
        _notify.ContextMenuStrip.Items.Add("Sair", null, SairAplicacaoMenuStrip_Click);
        _notify.Click += NotifyIcon_Click;

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();

        base.OnStartup(e);
    }

    private void SeedDatabase()
    {
        var contexto = _host.Services.GetRequiredService<EstacionamentoContexto>();

        if (contexto.Database.GetPendingMigrations().Any())
            contexto.Database.Migrate();

        contexto.Database.EnsureCreated();

        var vagasPrimeiroAndar = Enumerable.Range(1, 20)
            .Select(x => new Vaga() { Andar = 1, Codigo = "A", Numero = x, Ocupada = false })
            .ToList();

        var vagasSegundoAndar = Enumerable.Range(1, 15)
            .Select(x => new Vaga() { Andar = 1, Codigo = "B", Numero = x, Ocupada = false })
            .ToList();

        contexto.Vagas.AddRange(vagasPrimeiroAndar);
        contexto.Vagas.AddRange(vagasSegundoAndar);
        contexto.SaveChanges();
    }

    private void NotifyIcon_Click(object? sender, EventArgs e)
    {
        MainWindow.WindowState = WindowState.Normal;
        MainWindow.Activate();
    }

    private void SairAplicacaoMenuStrip_Click(object? sender, EventArgs e) 
        => Shutdown();

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();

        _notify.Dispose();

        base.OnExit(e);
    }
}
