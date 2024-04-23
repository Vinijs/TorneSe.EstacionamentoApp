using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Enums;

namespace TorneSe.EstacionamentoApp.Factories.Interfaces;

public interface IViewFactory
{
    UserControl CriarView(Paginas nomeView);
}
