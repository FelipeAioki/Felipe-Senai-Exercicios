using senai_CZBooks.webapi.Contexts;
using senai_CZBooks.webapi.Domains;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Repositories
{
    public class livroRepository : ILivroRepository
    {
        private string stringConexao = @"Data Source=LAB08DESK401; Initial Catalog= senai_CZBooks; user id=sa; pwd=sa132;";

        CZBooksContext ctx = new CZBooksContext();

        public Livro BuscarIdAutor(int idAutor)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idAutor);

                    //executa a query que armazena os dados do select no rdr
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Livro livroBuscado = new Livro
                        {
                            Titulo = rdr[0].ToString(),
                            Sinopse = rdr[1].ToString(),
                            DataDePublicacao = rdr[2].ToString()
                        };
                        //Retorna a consulta buscada com os dados obtidos
                        return livroBuscado;
                    }
                    //Se não, retorna null
                    return null;
                }
            }
        }

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
