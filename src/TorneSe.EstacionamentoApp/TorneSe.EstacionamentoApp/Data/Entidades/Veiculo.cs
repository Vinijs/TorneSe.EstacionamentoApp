namespace TorneSe.EstacionamentoApp.Data.Entidades;

public class Veiculo
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public string Ano { get; set; }
    public int IdCliente { get; set; }

    public Cliente Cliente { get; set; }
}
