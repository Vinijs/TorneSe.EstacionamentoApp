namespace TorneSe.EstacionamentoApp.Configs
{
    public sealed class ConfiguracoesAplicacao
    {
        public decimal ValorHora { get; set; }
        public string PathQrCode { get; set; } = string.Empty;
        public string PathExportarArquivo { get; set; } = string.Empty;
        public string NomeArquivoExportado { get; set; } = string.Empty;
    }
}
