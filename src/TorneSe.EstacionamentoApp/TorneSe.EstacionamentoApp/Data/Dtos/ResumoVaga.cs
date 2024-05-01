namespace TorneSe.EstacionamentoApp.Data.Dtos;

public class ResumoVaga
{
    public string NomeVaga { get; set; } = string.Empty;
    public string Placa { get; set; } = null!;
    public string ModeloMarca { get; set; }

    public ResumoVaga(string nomeVaga, string placa = "", string modeloMarca = "")
    {
        NomeVaga = nomeVaga;
        Placa = placa;
        ModeloMarca = modeloMarca;
    }
}
