using System.Collections.Generic;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Controls;
using TorneSe.EstacionamentoApp.Data.Entidades;

namespace TorneSe.EstacionamentoApp.Componentes;

/// <summary>
/// Interação lógica para VagasGridControl.xam
/// </summary>
public partial class VagasGridControl : UserControl
{
    private readonly List<Vaga> _vagas;
    private readonly string _donoComponente;

    public VagasGridControl(List<Vaga> vagas, string donoComponente)
    {
        InitializeComponent();
        _vagas = vagas;
        _donoComponente = donoComponente;
        MontarComponente();
    }

    private void MontarComponente()
    {
        vagasGrid.Children.Clear();

        for (int i = 0; i < _vagas.Count; i++)
        {
            VagaVeiculoCardControl cardVaga = new()
            {
                DonoComponente = _donoComponente
            };

            cardVaga.vagaNomeTextBlock.Text = _vagas[i].Nome;

            var coluna = i % 5;
            var linha = (i / 5) + 1;

            Grid.SetColumn(cardVaga, coluna);
            Grid.SetRow(cardVaga, linha);

            vagasGrid.Children.Add(cardVaga);
        }
    }

}
