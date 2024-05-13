using System.Security.Cryptography;
using System.Text;
using TorneSe.EstacionamentoApp.Business.Services.Interfaces;

namespace TorneSe.EstacionamentoApp.Business.Services;

public sealed class CriptografiaService : ICriptografiaService
{
    public string CalcularMD5Hash(string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = MD5.HashData(inputBytes);
        var sb = new StringBuilder();

        foreach (var t in hashBytes)
        {
            sb.Append(t.ToString("X2"));
        }

        return sb.ToString();
    }

    public bool CompararHashs(string input, string hash)
    {
        var inputHash = CalcularMD5Hash(input);

        return inputHash == hash;
    }
}
