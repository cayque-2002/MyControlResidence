using MyControlResidence.Api.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyControlResidence.Api.Domain.Entidades
{
    public class Transacao
    {
        public Transacao(string descricao, decimal valor, TipoTransacao tipo, long pessoaId, long categoriaId)
        {
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
            PessoaId = pessoaId;
            CategoriaId = categoriaId;
        }

        public long Id { get; set; }

        [MaxLength(400)]
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public TipoTransacao Tipo { get; set; }

        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public long PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public DateTime DataHoraCriacao { get; set; } = DateTime.UtcNow ;
    }

    //public class Transacao
    //{
    //    public long Id { get; private set; }
    //    public decimal Valor { get; private set; }
    //    public string Descricao { get; private set; }

    //    public Transacao(decimal valor, string descricao)
    //    {
    //        if (valor <= 0)
    //            throw new Exception("Valor deve ser maior que zero");

    //        Valor = valor;
    //        Descricao = descricao;
    //    }
    //}

}
