using MyControlResidence.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class CreateCategoriaDto
{
    [MaxLength(400)]
    public string Descricao { get; set; }

    public FinalidadeCategoria Finalidade { get; set; }
}