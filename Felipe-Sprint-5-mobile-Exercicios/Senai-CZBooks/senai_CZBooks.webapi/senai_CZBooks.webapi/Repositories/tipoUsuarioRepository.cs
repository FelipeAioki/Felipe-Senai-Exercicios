using senai_CZBooks.webapi.Contexts;
using senai_CZBooks.webapi.Domains;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Repositories
{
    public class tipoUsuariorepository : ITipoUsuarioRepository
    {
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// lista os tipos usuarios
        /// </summary>
        /// <returns></returns>
        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
