using MyControlResidence.Api.Enums;
using System.ComponentModel;

namespace MyControlResidence.Api.Entidades
{
    public class Transacao
    {
        public long Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public TipoTransacao Tipo { get; set; }

        public long CategoriaId { get; set; }

        public long PessoaId { get; set; }
    }
}
