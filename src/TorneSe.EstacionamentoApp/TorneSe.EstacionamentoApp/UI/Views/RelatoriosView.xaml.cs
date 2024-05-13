using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Business.Interfaces;
using TorneSe.EstacionamentoApp.Configs;
using TorneSe.EstacionamentoApp.Core.Comum;

namespace TorneSe.EstacionamentoApp.Views;

/// <summary>
/// Interação lógica para RelatoriosView.xam
/// </summary>
public partial class RelatoriosView : UserControl
{
    private readonly IReservaBusiness _reservaBusiness;
    private readonly string _pathArquivo;
    public RelatoriosView(IReservaBusiness reservaBusiness, IOptions<ConfiguracoesAplicacao> options)
    {
        InitializeComponent();
        _reservaBusiness = reservaBusiness;
        _pathArquivo = $"{options.Value.PathExportarArquivo}\\{options.Value.NomeArquivoExportado}";
        MontarComponente();
    }



    private async void MontarComponente()
    {
        List<ResumoFaturamentoFormaPagamento> valorFaturamentoPorFormaPagamento = await _reservaBusiness.ObterValorFaturamentoPorFormaPagamento();
        List<ResumoFaturamentoMensal> valorFaturamentoMensal = await _reservaBusiness.ObterValorFaturamentoUltimosMeses();

        PreencherInformacoesFaturamentoPorFormaPagamento(valorFaturamentoPorFormaPagamento);
        PreencherInformacoesFaturamentoMensal(valorFaturamentoMensal);
        await PreencherInformacoesOcupacao();
        await PreencherInformacoesUltimaEntradaESaida();
        await PreencherQuantidadeEntradasUltimaHora();
    }

    private async Task PreencherQuantidadeEntradasUltimaHora()
    {
        int entradasNaUltimaHora = await _reservaBusiness.ObterEntradasNaUltimaHora();
        gaugeChart.Value = entradasNaUltimaHora;
    }

    private async Task PreencherInformacoesUltimaEntradaESaida()
    {
        ResumoUltimaSaida dadosUltimaSaida = await _reservaBusiness.ObterUltimaSaida();
        placaUltimaSaidaTextBlock.Text = dadosUltimaSaida.Placa;
        vagaUltimaSaidaTextBlock.Text = dadosUltimaSaida.Vaga;
        dataUltimaSaidaTextBlock.Text = dadosUltimaSaida.DataHora.ToString("dd/MM/yyyy HH:mm:ss");

        ResumoUltimaEntrada dadosUltimaEntrada = await _reservaBusiness.ObterUltimaEntrada();
        placaUltimaEntradaTextBlock.Text = dadosUltimaEntrada.Placa;
        vagaUltimaEntradaTextBlock.Text = dadosUltimaEntrada.Vaga;
        dataUltimaEntradaTextBlock.Text = dadosUltimaEntrada.DataHora.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private void PreencherInformacoesFaturamentoMensal(List<ResumoFaturamentoMensal> valorFaturamentoMensal)
    {
        if (!valorFaturamentoMensal.Any())
            return;

        linhasChart.AxisX.Clear();
        linhasChart.AxisY.Clear();
        linhasChart.Series.Clear();

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

    private async Task PreencherInformacoesOcupacao()
    {
        ResumoOcupacao porcentagensVagas = await _reservaBusiness.ObterPorcentagemOcupacao();

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
    }

    private void PreencherInformacoesFaturamentoPorFormaPagamento(List<ResumoFaturamentoFormaPagamento> valorFaturamentoPorFormaPagamento)
    {
        if (!valorFaturamentoPorFormaPagamento.Any())
            return;

        colunasChart.Series.Clear();

        colunasChart.AxisX.Clear();
        colunasChart.AxisY.Clear();

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
    }

    private async void FaturamentoMensalFilterButtonFilter_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var dataInicial = datePickerFaturamentoFrom.SelectedDate;
        var dataFinal = datePickerFaturamentoTo.SelectedDate;

        if (!ValidarDatasSelecionadas(dataInicial, dataFinal))
        {
            return;
        }

        List<ResumoFaturamentoMensal> resumoFaturamentoMensal = await _reservaBusiness
            .ObterValorFaturamentoUltimosMeses(dataInicial.Value, dataFinal.Value);

        PreencherInformacoesFaturamentoMensal(resumoFaturamentoMensal);
    }

    private async void FaturamentoPorFormaPagamentoButtonFilter_Click(object sender, RoutedEventArgs e)
    {
        var dataInicial = datePickerFrom.SelectedDate;
        var dataFinal = datePickerTo.SelectedDate;

        if (!ValidarDatasSelecionadas(dataInicial, dataFinal))
        {
            return;
        }

        List<ResumoFaturamentoFormaPagamento> resumoFaturamentoFormaPagamento = await _reservaBusiness
            .ObterValorFaturamentoPorFormaPagamento(dataInicial.Value, dataFinal.Value);

        PreencherInformacoesFaturamentoPorFormaPagamento(resumoFaturamentoFormaPagamento);
    }

    private async void ExportarDadosReservasButton_Click(object sender, RoutedEventArgs e)
    {
        var dataInicial = datePickerFaturamentoFrom.SelectedDate;
        var dataFinal = datePickerFaturamentoTo.SelectedDate;

        if(!ValidarDatasSelecionadas(dataInicial, dataFinal)) 
        {
            return;
        }

        List<string[]> dadosCsv = await ObterDadosFormatadosRelatorio(dataInicial, dataFinal);

        await GravarArquivoCSV(_pathArquivo, dadosCsv);

        MessageBox.Show("Arquivo CSV gravado com sucesso!");

    }

    private async Task<List<string[]>> ObterDadosFormatadosRelatorio(DateTime? dataInicial, DateTime? dataFinal)
    {
        List<DadosRelatorio> dadosRelatorios = await _reservaBusiness
                    .ObterDadosRelatorio((DateTime)dataInicial!, (DateTime)dataFinal!);

        List<string[]> dadosCsv = new();

        var propriedades = typeof(DadosRelatorio).GetProperties();

        dadosCsv.Add(propriedades.Select(x => x.Name).ToArray());

        foreach (var dado in dadosRelatorios)
        {
            dadosCsv.Add(propriedades.Select(x => x.GetValue(dado)!.ToString()).ToArray()!);
        }

        return dadosCsv;
    }

    private static async Task GravarArquivoCSV(string caminhoArquivo, List<string[]> dados)
    {
        using var writer = new StreamWriter(caminhoArquivo, false, Encoding.UTF8);

        foreach (var linha in dados)
        {
            await writer.WriteLineAsync(string.Join(";", linha));
        }
    }

    private static bool ValidarDatasSelecionadas(System.DateTime? dataInicial, System.DateTime? dataFinal)
    {
        if (dataInicial is null || dataFinal is null)
        {
            MessageBox.Show("Selecione um periodo para filtrar");
            return false;
        }

        if (dataInicial > dataFinal)
        {
            MessageBox.Show("A data inicial não pode ser maior que a data final");
            return false;
        }

        return true;
    }
}
