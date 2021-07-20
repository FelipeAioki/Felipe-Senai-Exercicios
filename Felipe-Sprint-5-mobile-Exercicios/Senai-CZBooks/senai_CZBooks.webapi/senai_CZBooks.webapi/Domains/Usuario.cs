using System;
using System.Collections.Generic;

#nullable disable

namespace senai_CZBooks.webapi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
