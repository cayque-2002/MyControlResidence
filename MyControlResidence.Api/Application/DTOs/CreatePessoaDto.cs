using System.ComponentModel.DataAnnotations;

public class CreatePessoaDto
{
    [MaxLength(200)]
    public string Nome { get; set; }

    public int Idade { get; set; }
}