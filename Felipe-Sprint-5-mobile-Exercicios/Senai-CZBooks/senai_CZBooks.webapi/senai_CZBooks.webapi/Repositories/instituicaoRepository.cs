using senai_CZBooks.webapi.Contexts;
using senai_CZBooks.webapi.Domains;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Repositories
{
    public class instituicaoRepository : IInstituicaoRepository
    {
        CZBooksContext ctx = new CZBooksContext();

        /// <summary>
        /// lista as instituições
        /// </summary>
        /// <returns></returns>
        public List<Instituicao> Listar()
        {
            return ctx.Instituicaos.ToList();
        }
    }
}
