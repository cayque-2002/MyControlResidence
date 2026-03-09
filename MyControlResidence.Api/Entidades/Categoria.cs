using MyControlResidence.Api.Enums;
using System.ComponentModel;

namespace MyControlResidence.Api.Entidades
{
    public class Categoria
    {
        public long Id { get; set; }

        public string Descricao { get; set; }

        public FinalidadeCategoria Finalidade { get; set; }

    }
}
