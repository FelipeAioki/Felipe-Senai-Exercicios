using senai_CZBooks.webapi.Contexts;
using senai_CZBooks.webapi.Domains;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Repositories
{
    public class usuarioRepository : IUsuarioRepository
    {
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns></returns>
        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
