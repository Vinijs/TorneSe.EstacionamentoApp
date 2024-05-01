using System.Collections.Generic;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Controls;
using TorneSe.EstacionamentoApp.Data.Dtos;

namespace TorneSe.EstacionamentoApp.Componentes;

/// <summary>
/// Interação lógica para VagasGridControl.xam
/// </summary>
public partial class VagasGridControl : UserControl
{
    private readonly List<ResumoVaga> _vagas;
    private readonly string _donoComponente;

    public VagasGridControl(List<ResumoVaga> vagas, string donoComponente)
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
            VagaVeiculoCardControl cardVaga = new(_vagas[i])
            {
                DonoComponente = _donoComponente
            };

            var coluna = i % 5;
            var linha = (i / 5) + 1;

            Grid.SetColumn(cardVaga, coluna);
            Grid.SetRow(cardVaga, linha);

            vagasGrid.Children.Add(cardVaga);
        }
    }

}
