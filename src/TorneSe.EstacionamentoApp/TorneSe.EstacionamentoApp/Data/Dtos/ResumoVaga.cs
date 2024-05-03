namespace TorneSe.EstacionamentoApp.Data.Dtos;

public class ResumoVaga
{
    public int IdVaga { get; set; }
    public string NomeVaga { get; set; } = string.Empty;
    public string Placa { get; set; } = null!;
    public string ModeloMarca { get; set; }

    public ResumoVaga(int idVaga, string nomeVaga, string placa = null!, string modeloMarca = null!)
    {
        IdVaga = idVaga;
        NomeVaga = nomeVaga;
        Placa = placa;
        ModeloMarca = modeloMarca;
    }

}
