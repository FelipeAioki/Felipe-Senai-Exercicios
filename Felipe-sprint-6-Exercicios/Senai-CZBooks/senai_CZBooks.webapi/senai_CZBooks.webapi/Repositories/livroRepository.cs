using senai_CZBooks.webapi.Contexts;
using senai_CZBooks.webapi.Domains;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Repositories
{
    public class livroRepository : ILivroRepository
    {
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="NovoLivro"></param>
        public void Cadastrar(Livro NovoLivro)
        {
            ctx.Livros.Add(NovoLivro);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista os livros
        /// </summary>
        /// <returns></returns>
        public List<Livro> Listar()
        {
            return ctx.Livros.ToList();
        }
    }
}
