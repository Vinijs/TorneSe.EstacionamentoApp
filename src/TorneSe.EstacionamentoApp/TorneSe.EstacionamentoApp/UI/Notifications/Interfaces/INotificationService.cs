using System;

namespace TorneSe.EstacionamentoApp.Notifications.Interfaces;

public interface INotificationService
{
    void Notificar(int intervalo, string titulo, string mensagem, EventHandler? handler = null);
}
