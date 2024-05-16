using TorneSe.EstacionamentoApp.UI.Enums;

namespace TorneSe.EstacionamentoApp.UI.Dtos;

public record struct BateriaInfo(string Porcentagem, BateriaStatus BateriaStatus);
