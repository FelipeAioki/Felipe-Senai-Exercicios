using System;
using System.Collections.Generic;

#nullable disable

namespace senai_CZBooks.webapi.Domains
{
    public partial class Livro
    {
        public int IdLivro { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string DataDePublicacao { get; set; }
        public decimal Preco { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
