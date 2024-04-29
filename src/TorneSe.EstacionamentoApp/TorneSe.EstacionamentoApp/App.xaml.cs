using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Forms = System.Windows.Forms;
using TorneSe.EstacionamentoApp.Extensions;

namespace TorneSe.EstacionamentoApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;
    private readonly Forms.NotifyIcon _notify;
    public App()
    {
        _host = Host
            .CreateDefaultBuilder()
            .AddStores()
            .AddBusiness()
            .AddFactories()
            .AddViews()
            .Build();

        _notify = new Forms.NotifyIcon
        {
            Text = "Tornese Estacionamento App",
            Visible = true,
            Icon = new System.Drawing.Icon("Recursos/tornese.ico")
        };
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();

        _notify.Dispose();

        base.OnExit(e);
    }
}
