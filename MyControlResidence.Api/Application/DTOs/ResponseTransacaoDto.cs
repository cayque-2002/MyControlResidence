using MyControlResidence.Api.Domain.Enums;

public class ResponseTransacaoDto
{
    public long Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public TipoTransacao Tipo { get; set; }
    public long CategoriaId { get; set; }
    public long PessoaId { get; set; }
    public DateTime DataHoraCriacao { get; set; }

}