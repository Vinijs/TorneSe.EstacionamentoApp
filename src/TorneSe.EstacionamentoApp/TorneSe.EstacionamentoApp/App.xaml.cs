using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Forms = System.Windows.Forms;
using TorneSe.EstacionamentoApp.Extensions;
using System;

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
            .AddStores()
            .AddNotifications()
            .AddBusiness()
            .AddFactories()
            .AddViews()
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        _notify = _host.Services.GetRequiredService<Forms.NotifyIcon>();

        //Menus
        _notify.ContextMenuStrip = new Forms.ContextMenuStrip();
        _notify.ContextMenuStrip.Items.Add("Sair", null, SairAplicacaoMenuStrip_Click);
        _notify.Click += NotifyIcon_Click;

        //Notificações
        _notify.ShowBalloonTip(1000, "Entrada Veiculo", "Entrada realizada com sucesso do veiculo UHUHA-1918"
            , Forms.ToolTipIcon.Info);
        _notify.BalloonTipClicked += (s, e) => Forms.MessageBox.Show("Clicou no balão");

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();

        base.OnStartup(e);
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
