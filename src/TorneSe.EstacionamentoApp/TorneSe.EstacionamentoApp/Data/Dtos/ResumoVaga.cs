namespace TorneSe.EstacionamentoApp.Data.Dtos;

public class ResumoVaga
{
    public string NomeVaga { get; set; } = string.Empty;
    public string Placa { get; set; } = null!;
    public string NomeCliente { get; set; }

    public ResumoVaga(string nomeVaga, string placa = "", string nomeCliente = "")
    {
        NomeVaga = nomeVaga;
        Placa = placa;
        NomeCliente = nomeCliente;
    }
}
