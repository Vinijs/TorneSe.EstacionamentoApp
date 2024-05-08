using System;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Core.Entidades;

namespace TorneSe.EstacionamentoApp.UI.Helpers;

public static class DialogHelper
{
    public static void GerarTicketEntrada(Veiculo veiculo)
    {
        // Crie uma instância da classe PrintDialog
        PrintDialog printDialog = new();

        if (printDialog.ShowDialog() == true)
        {
            // Configurar o conteúdo a ser impresso
            FixedDocument document = new();
            PageContent pageContent = new();
            FixedPage fixedPage = new();

            // Obter a data e hora atual
            DateTime dataHoraAtual = DateTime.Now;

            //Campos do ticket
            TextBlock textBlockTitulo = new()
            {
                Text = $"Ticket de Entrada - Data e Hora: {dataHoraAtual.ToString("dd/MM/yyyy HH:mm:ss")}",
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };
            FixedPage.SetLeft(textBlockTitulo, 10);
            FixedPage.SetTop(textBlockTitulo, 0);
            fixedPage.Children.Add(textBlockTitulo);

            TextBlock dadosVeiculosTextBlock = new()
            {
                Text = "Dados do Veículo",
                FontSize = 16,
                FontWeight = FontWeights.Bold
            };
            FixedPage.SetLeft(dadosVeiculosTextBlock, 10);
            FixedPage.SetTop(dadosVeiculosTextBlock, 40);
            fixedPage.Children.Add(dadosVeiculosTextBlock);

            TextBlock textBlockPlaca = new()
            {
                Text = "Placa: " + veiculo.Placa,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockPlaca, 10);
            FixedPage.SetTop(textBlockPlaca, 100);
            fixedPage.Children.Add(textBlockPlaca);

            TextBlock textBlockModelo = new()
            {
                Text = "Modelo: " + veiculo.Modelo,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockModelo, 10);
            FixedPage.SetTop(textBlockModelo, 120);
            fixedPage.Children.Add(textBlockModelo);

            TextBlock textBlockMarca = new()
            {
                Text = "Marca: " + veiculo.Marca,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockMarca, 10);
            FixedPage.SetTop(textBlockMarca, 140);
            fixedPage.Children.Add(textBlockMarca);

            TextBlock textBlockCor = new()
            {
                Text = "Cor: " + veiculo.Cor,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockCor, 10);
            FixedPage.SetTop(textBlockCor, 160);
            fixedPage.Children.Add(textBlockCor);

            TextBlock textBlockAno = new()
            {
                Text = "Ano: " + veiculo.Ano,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockAno, 10);
            FixedPage.SetTop(textBlockAno, 180);
            fixedPage.Children.Add(textBlockAno);

            // Adicionar a página fixa ao documento
            ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
            document.Pages.Add(pageContent);

            // Definir o tamanho do papel
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA7);
            printDialog.PrintTicket.OutputColor = OutputColor.Monochrome;
            printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
            printDialog.PrintTicket.PageBorderless = PageBorderless.None;

            // Imprimir o conteúdo
            printDialog.PrintDocument(document.DocumentPaginator, "Ticket de Estacionamento");
        }
    }

    public static void GerarTicketSaida(ResumoSaida resumoSaida, ResumoVaga resumoVaga)
    {
        // Crie uma instância da classe PrintDialog
        PrintDialog printDialog = new();

        if (printDialog.ShowDialog() == true)
        {
            // Configurar o conteúdo a ser impresso
            FixedDocument document = new();
            PageContent pageContent = new();
            FixedPage fixedPage = new();

            // Obter a data e hora atual
            DateTime dataHoraAtual = DateTime.Now;

            //Campos do ticket
            TextBlock textBlockTitulo = new()
            {
                Text = $"Ticket de Saida - Data e Hora: {dataHoraAtual.ToString("dd/MM/yyyy HH:mm:ss")}",
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };
            FixedPage.SetLeft(textBlockTitulo, 10);
            FixedPage.SetTop(textBlockTitulo, 0);
            fixedPage.Children.Add(textBlockTitulo);

            TextBlock dadosVeiculosTextBlock = new()
            {
                Text = "Dados do Veículo",
                FontSize = 16,
                FontWeight = FontWeights.Bold
            };
            FixedPage.SetLeft(dadosVeiculosTextBlock, 10);
            FixedPage.SetTop(dadosVeiculosTextBlock, 40);
            fixedPage.Children.Add(dadosVeiculosTextBlock);

            TextBlock textBlockPlaca = new()
            {
                Text = "Placa: " + resumoVaga.Placa,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockPlaca, 10);
            FixedPage.SetTop(textBlockPlaca, 100);
            fixedPage.Children.Add(textBlockPlaca);

            TextBlock textBlockModelo = new()
            {
                Text = "Modelo/Marca: " + resumoVaga.ModeloMarca,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockModelo, 10);
            FixedPage.SetTop(textBlockModelo, 120);
            fixedPage.Children.Add(textBlockModelo);

            TextBlock textBlockHoraEntrada = new()
            {
                Text = "Hora Entrada: " + resumoSaida.HoraEntrada.ToString("dd/MM/yyyy HH:mm:ss"),
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockHoraEntrada, 10);
            FixedPage.SetTop(textBlockHoraEntrada, 140);
            fixedPage.Children.Add(textBlockHoraEntrada);

            TextBlock textBlockHoraSaida = new()
            {
                Text = "Hora Saida: " + resumoSaida.HoraSaida.ToString("dd/MM/yyyy HH:mm:ss"),
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockHoraSaida, 10);
            FixedPage.SetTop(textBlockHoraSaida, 160);
            fixedPage.Children.Add(textBlockHoraSaida);

            TextBlock textBlockValorHora = new()
            {
                Text = "Valor Hora: " + resumoSaida.ValorHora,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockValorHora, 10);
            FixedPage.SetTop(textBlockValorHora, 180);
            fixedPage.Children.Add(textBlockValorHora);

            TextBlock textBlockValorTotal = new()
            {
                Text = "Valor Total: " + resumoSaida.ValorTotal,
                FontSize = 14
            };
            FixedPage.SetLeft(textBlockValorTotal, 10);
            FixedPage.SetTop(textBlockValorTotal, 200);
            fixedPage.Children.Add(textBlockValorTotal);

            // Adicionar a página fixa ao documento
            ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
            document.Pages.Add(pageContent);

            // Definir o tamanho do papel
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA7);
            printDialog.PrintTicket.OutputColor = OutputColor.Monochrome;
            printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
            printDialog.PrintTicket.PageBorderless = PageBorderless.None;

            // Imprimir o conteúdo
            printDialog.PrintDocument(document.DocumentPaginator, "Ticket de Estacionamento");
        }
    }
}
