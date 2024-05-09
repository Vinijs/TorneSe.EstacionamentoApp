using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Core.Comum;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para RelatoriosView.xam
/// </summary>
public partial class RelatoriosView : UserControl
{
    private readonly IReservaBusiness _reservaBusiness;
    public RelatoriosView(IReservaBusiness reservaBusiness)
    {
        InitializeComponent();
        _reservaBusiness = reservaBusiness;
        MontarComponente();
    }



    private async void MontarComponente()
    {
        //Dados ficticios de forma pagamento

        ResumoOcupacao porcentagensVagas = await _reservaBusiness.ObterPorcentagemOcupacao();
        List<ResumoFaturamentoFormaPagamento> valorFaturamentoPorFormaPagamento = await _reservaBusiness.ObterValorFaturamentoPorFormaPagamento();
        List<ResumoFaturamentoMensal> valorFaturamentoMensal = await _reservaBusiness.ObterValorFaturamentoUltimosMeses();



        colunasChart.Series.Clear();

        colunasChart.AxisX.Add(new Axis
        {
            Title = "Formas de Pagamento",
            Labels = valorFaturamentoPorFormaPagamento.Select(x => x.FormaPagamento.ToString()).ToList(),
        });

        colunasChart.AxisY.Add(new Axis
        {
            Title = "Valor em R$",
            LabelFormatter = value => value.ToString("C"),
            Foreground = System.Windows.Media.Brushes.White,
            ShowLabels = true,
            Separator = new LiveCharts.Wpf.Separator
            {
                StrokeThickness = 1,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(new[] { 2d }),
                Stroke = System.Windows.Media.Brushes.White
            },
            MinValue = 0,
            MaxValue = valorFaturamentoPorFormaPagamento.Max(x => x.ValorAgregado) + 1000
        });

        var columnSeries = new ColumnSeries
        {
            Values = new ChartValues<double>(valorFaturamentoPorFormaPagamento.Select(x => x.ValorAgregado)),
            Title = "Recebimentos por forma pagamento",
            DataLabels = true,
            LabelPoint = point => point.Y.ToString("C"),
            Foreground = System.Windows.Media.Brushes.DodgerBlue,
            Fill = System.Windows.Media.Brushes.DodgerBlue,
        };

        colunasChart.Series.Add(columnSeries);

        //Ocupação exemplo
        pieChart.Series.Clear();


        // Crie uma instância da Series para armazenar os dados do gráfico
        var ocupadas = new PieSeries
        {
            Values = new ChartValues<double> { porcentagensVagas.Ocupadas },
            DataLabels = true,
            Title = nameof(porcentagensVagas.Ocupadas),
            Fill = System.Windows.Media.Brushes.Red,
            LabelPoint = point => $"{point.Y}%"
        };

        var livres = new PieSeries
        {
            Values = new ChartValues<double> { porcentagensVagas.Livres },
            DataLabels = true,
            Title = nameof(porcentagensVagas.Livres),
            Fill = System.Windows.Media.Brushes.Green,
            LabelPoint = point => $"{point.Y}%"
        };

        // Adicione a Series ao Chart
        pieChart.Series.Add(ocupadas);
        pieChart.Series.Add(livres);

        linhasChart.AxisX.Add(new Axis
        {
            Title = "Mês",
            Labels = valorFaturamentoMensal.Select(x => x.Mes).ToList(),
        });

        linhasChart.AxisY.Add(new Axis
        {
            Title = "Valor R$",
            LabelFormatter = value => value.ToString("C"),
            Foreground = System.Windows.Media.Brushes.White,
            ShowLabels = true,
            Separator = new LiveCharts.Wpf.Separator
            {
                StrokeThickness = 1,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 2d }),
                Stroke = System.Windows.Media.Brushes.White
            },
            MinValue = 0,
            MaxValue = valorFaturamentoMensal.Max(x => x.ValorAgregado) + 1000
        });

        var series = new LineSeries
        {
            Values = new ChartValues<double>(valorFaturamentoMensal.Select(x => x.ValorAgregado)),
            Title = "Faturamento Mensal",
            DataLabels = true,
            LabelPoint = point => point.Y.ToString("C"),
            Foreground = System.Windows.Media.Brushes.DodgerBlue,
            Fill = System.Windows.Media.Brushes.DodgerBlue,
            Stroke = System.Windows.Media.Brushes.DodgerBlue,
        };

        linhasChart.Series.Add(series);
    }
}
