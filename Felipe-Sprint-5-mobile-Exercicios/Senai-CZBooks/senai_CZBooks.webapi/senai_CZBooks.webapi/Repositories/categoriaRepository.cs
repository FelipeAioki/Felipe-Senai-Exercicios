using senai_CZBooks.webapi.Contexts;
using senai_CZBooks.webapi.Domains;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Repositories
{
    public class categoriaRepository : ICategoriaRepository

    {
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="NovaCategoria"></param>
        public void Cadastrar(Categoria NovaCategoria)
        {
            ctx.Categoria.Add(NovaCategoria);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista as categorias
        /// </summary>
        /// <returns></returns>
        public List<Categoria> Listar()
        {
            return ctx.Categoria.ToList();
        }
    }
}
