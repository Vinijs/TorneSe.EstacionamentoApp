using System.Runtime.InteropServices;
using System.Windows.Forms;
using TorneSe.EstacionamentoApp.UI.Dtos;
using TorneSe.EstacionamentoApp.UI.Enums;

namespace TorneSe.EstacionamentoApp.UI.Helpers;

public static class SystemStatusHelper
{
    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

    public static bool IsConnectedToInternet() 
        => InternetGetConnectedState(out _, 0);

    public static BateriaInfo ObterStatusBateria()
    {
        PowerStatus powerStatus = SystemInformation.PowerStatus;
        var porcentagem = powerStatus.BatteryLifePercent.ToString("P0");

        if (powerStatus.BatteryLifePercent >= 50 && powerStatus.BatteryLifePercent <= 80)
            return new BateriaInfo(porcentagem, BateriaStatus.Media);

        return powerStatus.BatteryChargeStatus switch
        {
            BatteryChargeStatus.High => new BateriaInfo(porcentagem, BateriaStatus.Cheia) ,
            BatteryChargeStatus.Low => new BateriaInfo(porcentagem, BateriaStatus.Baixa),
            BatteryChargeStatus.Critical => new BateriaInfo(porcentagem, BateriaStatus.Critica),
            BatteryChargeStatus.Charging => new BateriaInfo(porcentagem, BateriaStatus.Carregando),
            BatteryChargeStatus.NoSystemBattery => new BateriaInfo(porcentagem,BateriaStatus.SemBateria),
            BatteryChargeStatus.Unknown => new BateriaInfo(porcentagem, BateriaStatus.SemBateria),            
            _ => new BateriaInfo(porcentagem, BateriaStatus.SemBateria)
        };
    }
}
