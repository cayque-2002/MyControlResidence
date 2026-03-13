using MyControlResidence.Api.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyControlResidence.Api.Domain.Entidades
{
    public class Transacao
    {
        public long Id { get; set; }

        [MaxLength(400)]
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public TipoTransacao Tipo { get; set; }

        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public long PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public DateTime DataHoraCriacao { get; set; } = DateTime.Now;
    }
}
