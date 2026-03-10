using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class CreateTransacaoDto
{
    [MaxLength(400)]
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public TipoTransacao Tipo { get; set; }
    public long CategoriaId { get; set; }
    public long PessoaId { get; set; }
    public DateTime DataHoraCriacao { get; set; }

}