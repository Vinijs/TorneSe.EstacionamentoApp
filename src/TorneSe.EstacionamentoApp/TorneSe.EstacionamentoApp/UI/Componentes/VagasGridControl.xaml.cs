using System.Collections.Generic;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Controls;
using TorneSe.EstacionamentoApp.Data.Dtos;
using TorneSe.EstacionamentoApp.UI.Interfaces;

namespace TorneSe.EstacionamentoApp.Componentes;

/// <summary>
/// Interação lógica para VagasGridControl.xam
/// </summary>
public partial class VagasGridControl : UserControl
{
    private readonly List<ResumoVaga> _vagas;
    private readonly string _donoComponente;
    private readonly IVeiculoBusiness _veiculoBusiness;

    public VagasGridControl(List<ResumoVaga> vagas, string donoComponente, 
                            IVeiculoBusiness veiculoBusiness)
    {
        InitializeComponent();
        _vagas = vagas;
        _donoComponente = donoComponente;
        _veiculoBusiness = veiculoBusiness;
        MontarComponente();
    }

    private void MontarComponente()
    {
        vagasGrid.Children.Clear();

        for (int i = 0; i < _vagas.Count; i++)
        {
            VagaVeiculoCardControl cardVaga = new(_vagas[i], _veiculoBusiness)
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
