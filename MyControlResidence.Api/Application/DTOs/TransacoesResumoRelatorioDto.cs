public class TransacoesResumoRelatorioDto
{
    public string Chave { get; set; }

    public decimal Receita { get; set; }

    public decimal Despesas { get; set; }

    public decimal Saldo { get; set; }

    public List<TransacoesItensRelatorioDto> Transacoes { get; set; }
}