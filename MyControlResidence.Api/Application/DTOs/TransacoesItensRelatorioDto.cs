
using MyControlResidence.Api.Domain.Enums;

public class TransacoesItensRelatorioDto
{
    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public DateTime DataHoraCriacao { get; set; }
}