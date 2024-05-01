using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
using TorneSe.EstacionamentoApp.Notifications;
using TorneSe.EstacionamentoApp.Notifications.Interfaces;

namespace TorneSe.EstacionamentoApp.Extensions;

public static class AddNotificationsHostBuilderExtensions
{
    public static IHostBuilder AddNotifications(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
        {
            services.AddTransient(service => new NotifyIcon
        {
            Text = "Tornese Estacionamento App",
            Visible = true,
            Icon = new System.Drawing.Icon("UI/Recursos/tornese.ico")
        });
            services.AddTransient<INotificationService, WindowsNotificationService>();
        });
        return hostBuilder;
    }
}
