using System;
using System.Windows.Forms;
using TorneSe.EstacionamentoApp.Notifications.Interfaces;

namespace TorneSe.EstacionamentoApp.Notifications;

public class WindowsNotificationService : INotificationService
{
    private readonly NotifyIcon _notificationIcon;
    public WindowsNotificationService(NotifyIcon notifyIcon) 
        => _notificationIcon = notifyIcon;
    public void Notificar(int intervalo, string titulo, string mensagem, string tipoIcone, EventHandler? handler = null)
    {
        _notificationIcon.ShowBalloonTip(1000, "Entrada Veiculo", "Entrada realizada com sucesso do veiculo UHUHA-1918"
           , ToolTipIcon.Info);
        _notificationIcon.BalloonTipClicked += (s, e) => MessageBox.Show("Clicou no balão");
    }
}
