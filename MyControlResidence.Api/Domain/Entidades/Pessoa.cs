using System.ComponentModel.DataAnnotations;

namespace MyControlResidence.Api.Domain.Entidades
{
    public class Pessoa
    {
        public long Id { get; set; }

        [MaxLength(200)]
        public string Nome { get; set; }

        public int Idade { get; set; }

        public DateTime DataHoraCriacao { get; set; } = DateTime.UtcNow;
    }
}
