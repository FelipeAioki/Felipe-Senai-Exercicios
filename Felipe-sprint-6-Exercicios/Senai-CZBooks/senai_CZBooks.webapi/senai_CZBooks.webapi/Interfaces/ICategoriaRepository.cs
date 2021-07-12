using senai_CZBooks.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Interfaces
{
    interface ICategoriaRepository
    {

        /// <summary>
        /// Lista as categorias
        /// </summary>
        /// <returns></returns>
        List<Categoria> Listar();

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="NovaCategoria"></param>
        void Cadastrar(Categoria NovaCategoria);
    }
}
