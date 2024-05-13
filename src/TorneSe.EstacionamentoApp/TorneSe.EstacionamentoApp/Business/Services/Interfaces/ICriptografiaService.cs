namespace TorneSe.EstacionamentoApp.Business.Services.Interfaces;

public interface ICriptografiaService
{
    string CalcularMD5Hash(string input);
    bool CompararHashs(string input, string hash);
}
