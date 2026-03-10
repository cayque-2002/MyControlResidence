public class ResponseRelatorioDto
{
    public List<TransacoesResumoRelatorioDto> Itens { get; set; }

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal TotalSaldo { get; set; }
}