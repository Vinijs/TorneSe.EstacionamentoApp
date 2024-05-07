using System;
using TorneSe.EstacionamentoApp.Business.Enums;

namespace TorneSe.EstacionamentoApp.Core.Comum;

public class ResumoSaida
{
    public DateTime HoraEntrada { get; set; }
    public DateTime HoraSaida { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
    public int TotalHoras 
    { 
        get 
        {
            return (int)Math.Round(HoraSaida.Subtract(HoraEntrada).TotalHours);
        } 
    }

    public decimal ValorHora { get; set; }
    public decimal ValotTotal
    {
        get 
        {
            return TotalHoras * ValorHora;
        }
    }
}
