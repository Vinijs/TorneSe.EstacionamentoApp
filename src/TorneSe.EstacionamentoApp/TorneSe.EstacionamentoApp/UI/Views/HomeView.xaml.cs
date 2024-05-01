using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para HomeView.xam
/// </summary>
public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        horaTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
        DispatcherTimer timer = new()
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        horaTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
    }
}
