using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TorneSe.EstacionamentoApp.Componentes;

/// <summary>
/// Interação lógica para LoadingControl.xam
/// </summary>
public partial class LoadingControl : UserControl
{
    public LoadingControl(int duracao = 1, string corAnimacao = "DodgerBlue")
    {
        InitializeComponent();
        doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(duracao));
        animacaoPath.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(corAnimacao));
    }
}
