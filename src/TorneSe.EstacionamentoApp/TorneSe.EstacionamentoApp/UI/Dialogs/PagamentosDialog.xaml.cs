using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using TorneSe.EstacionamentoApp.Business.Enums;
using TorneSe.EstacionamentoApp.Core.Comum;

namespace TorneSe.EstacionamentoApp.UI.Dialogs;
public partial class PagamentosDialog : Window
{
    private readonly ResumoSaida _resumoSaida;
    private readonly string _pathQrCode;

    public PagamentosDialog(ResumoSaida resumoSaida, string pathQrCode)
    {
        InitializeComponent();
        InitializeComponent();
        Owner = Application.Current.MainWindow;
        _resumoSaida = resumoSaida;
        _pathQrCode = pathQrCode;
        MontarComponente();
    }

    private void MontarComponente()
    {
        dadosHoraEntradaTextblock.Text = _resumoSaida.HoraEntrada.ToString("dd/MM/yyyy HH:mm:ss");
        dadosHoraSaidaTextBlock.Text = _resumoSaida.HoraSaida.ToString("dd/MM/yyyy HH:mm:ss");
        dadosTotalHorasTextBlock.Text = _resumoSaida.TotalHoras.ToString();
        dadosValorHoraTextBlock.Text = _resumoSaida.ValorHora.ToString("C");
        dadosValorTotalTextBlock.Text = _resumoSaida.ValorTotal.ToString("C");
        dadosTipoPagamentoTextBlock.Text = _resumoSaida.FormaPagamento.ToString();

        if (_resumoSaida.FormaPagamento is FormaPagamento.Pix)
            GerarQrCode();
    }

    private void GerarQrCode()
    {
        //QRCodeGenerator qrGenerator = new();
        //QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://google.com.br", QRCodeGenerator.ECCLevel.Q);
        //QRCode qrCode = new(qrCodeData);

        //// Converter o QR code para uma imagem Bitmap
        //Bitmap qrCodeImage = qrCode.GetGraphic(20);

        //// Exibir a imagem do QR code em um controle de imagem
        //var imageControl = new System.Windows.Controls.Image();
        //imageControl.Source = ConvertBitmapToBitmapImage(qrCodeImage);
        //imageControl.Width = 200;
        //imageControl.Height = 200;

        //pagamentoGrid.Children.Add(imageControl);

        var width = informacoesPagamentoGrid.Width;
        var height = informacoesPagamentoGrid.Height;
        pagamentoGrid.Width = width;
        pagamentoGrid.Height = height;
        pagamentoGrid.Visibility = Visibility.Visible;

        if(!string.IsNullOrWhiteSpace(_pathQrCode) 
            && File.Exists(_pathQrCode))
        {
            qrcodeImage.Source = new BitmapImage(new Uri(_pathQrCode));
            qrcodeImage.Visibility = Visibility.Visible;
        }
        else
        {
            dadosQrCodeTextBlock.Text = "Não foi possível gerar o QRCode";
            dadosQrCodeTextBlock.Visibility = Visibility.Visible;
        }
    }

    private static BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
    {
        using MemoryStream memoryStream = new();
        // Salva o bitmap na memória usando um formato de imagem suportado pelo BitmapImage
        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
        memoryStream.Position = 0;

        // Cria um novo BitmapImage e carrega-o a partir do MemoryStream
        BitmapImage bitmapImage = new();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memoryStream;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
        bitmapImage.Freeze(); // Opcional: congela o objeto BitmapImage para melhor desempenho

        return bitmapImage;
    }



    private void Cancelar_ButtonClick(object sender, RoutedEventArgs e) 
        => Close();

    private void Confirmar_ButtonClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }
}
