using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Windows.Controls;
using TorneSe.EstacionamentoApp.Configs;
using TorneSe.EstacionamentoApp.Controls;
using TorneSe.EstacionamentoApp.Core.Comum;
using TorneSe.EstacionamentoApp.Store;
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
    private readonly VagasStore _store;
    private readonly IOptions<ConfiguracoesAplicacao> _options;

    public VagasGridControl(List<ResumoVaga> vagas, string donoComponente, 
                            IVeiculoBusiness veiculoBusiness,
                            VagasStore store,
                            IOptions<ConfiguracoesAplicacao> options)
    {
        InitializeComponent();
        _vagas = vagas;
        _donoComponente = donoComponente;
        _veiculoBusiness = veiculoBusiness;
        _store = store;
        _options = options;
        MontarComponente();
    }

    private void MontarComponente()
    {
        vagasGrid.Children.Clear();

        for (int i = 0; i < _vagas.Count; i++)
        {
            VagaVeiculoCardControl cardVaga = new(_vagas[i], _veiculoBusiness, _store, _options)
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
