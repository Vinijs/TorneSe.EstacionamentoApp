using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para RelatoriosView.xam
/// </summary>
public partial class RelatoriosView : UserControl
{
    public RelatoriosView()
    {
        InitializeComponent();
        MontarComponente();
    }

    private void MontarComponente()
    {
        //Dados ficticios de forma pagamento
        colunasChart.Series.Clear();

        colunasChart.AxisX.Add(new Axis
        {
            Title = "Formas de Pagamento",
            Labels = new[] { "Dinheiro", "Cartão de Crédito", "Pix" }
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
            MaxValue = 10000
        });

        var columnSeries = new ColumnSeries
        {
            Values = new ChartValues<double> { 4000, 7000, 2000 },
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
            Values = new ChartValues<double> { 40 },
            DataLabels = true,
            Title = "Ocupadas",
            Fill = System.Windows.Media.Brushes.Red,
            LabelPoint = point => $"{point.Y}%"
        };

        var livres = new PieSeries
        {
            Values = new ChartValues<double> { 60 },
            DataLabels = true,
            Title = "Livres",
            Fill = System.Windows.Media.Brushes.Green,
            LabelPoint = point => $"{point.Y}%"
        };

        // Adicione a Series ao Chart
        pieChart.Series.Add(ocupadas);
        pieChart.Series.Add(livres);

        linhasChart.AxisX.Add(new Axis
        {
            Title = "Mês",
            Labels = new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun" }
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
            MaxValue = 30000
        });

        var series = new LineSeries
        {
            Values = new ChartValues<double> { 4000, 7000, 2900, 9000, 5000, 9900 },
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
