using MyControlResidence.Api.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyControlResidence.Api.Domain.Entidades
{
    public class Categoria
    {
        public long Id { get; set; }

        [MaxLength(400)]
        public string Descricao { get; set; }

        public FinalidadeCategoria Finalidade { get; set; }
        public DateTime DataHoraCriacao { get; set; }

    }
}
