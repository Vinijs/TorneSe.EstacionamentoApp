using System;
using System.Windows.Controls;
using System.Windows.Threading;
using TorneSe.EstacionamentoApp.Business.Interfaces;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para HomeView.xam
/// </summary>
public partial class HomeView : UserControl
{
    private readonly IReservaBusiness _reservaBusiness;

    public HomeView(IReservaBusiness reservaBusiness)
    {
        InitializeComponent();
        horaTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
        DispatcherTimer timer = new()
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        timer.Tick += Timer_Tick;
        timer.Start();
        _reservaBusiness = reservaBusiness;
        MontarComponente();
    }

    private async void MontarComponente()
    {
        var ocupacao = await _reservaBusiness.ObterPorcentagemOcupacao();
        vagasDisponiveisTextBlock.Text = ocupacao.QuantidadeLivres.ToString();
        vagasOcupadasTextBlock.Text = ocupacao.QuantidadeOcupadas.ToString();
        porcentagemOcupacaoTextBlock.Text = $"{ ocupacao.Ocupadas}%";
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        horaTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
    }
}
