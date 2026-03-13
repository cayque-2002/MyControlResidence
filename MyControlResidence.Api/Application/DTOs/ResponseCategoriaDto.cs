using MyControlResidence.Api.Domain.Enums;

public class ResponseCategoriaDto
{
    public long Id { get; set; }

    public string Descricao { get; set; }

    public FinalidadeCategoria Finalidade { get; set; }

    public DateTime DataHoraCriacao { get; set; }
}