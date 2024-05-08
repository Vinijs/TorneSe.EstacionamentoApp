namespace TorneSe.EstacionamentoApp.Core.Comum;

public class ResumoVaga
{
    public int IdVaga { get; set; }
    public string NomeVaga { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string ModeloMarca { get; set; }
    public int IdVeiculo { get; set; }

    public ResumoVaga(int idVaga, 
                      string nomeVaga,
                      string placa = null!,
                      string modeloMarca = null!,
                      int idVeiculo = default)
    {
        IdVaga = idVaga;
        NomeVaga = nomeVaga;
        Placa = placa;
        ModeloMarca = modeloMarca;
        IdVeiculo = idVeiculo;
    }

}
