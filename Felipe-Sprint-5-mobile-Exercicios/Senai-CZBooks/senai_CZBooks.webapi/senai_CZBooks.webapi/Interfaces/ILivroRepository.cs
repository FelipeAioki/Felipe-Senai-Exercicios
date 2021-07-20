using senai_CZBooks.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Interfaces
{
    interface ILivroRepository
    {
        /// <summary>
        /// Lista os livros
        /// </summary>
        /// <returns></returns>
        List<Livro> Listar();

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="NovoLivro"></param>
        void Cadastrar(Livro NovoLivro);

        /// <summary>
        /// Busca livros atravez do autor
        /// </summary>
        /// <param name="idAutor"></param>
        /// <returns></returns>
        Livro BuscarIdAutor(int idAutor);
    }
}
