using Microsoft.Data.SqlClient;
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

        private string stringConexao = @"Data Source=LAB08DESK401; Initial Catalog= senai_CZBooks; user id=sa; pwd=sa132;";


        CZBooksContext ctx = new CZBooksContext();


        /// <summary>
        /// metodo de login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public Usuario buscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdTipoUsuario ,Email, Senha, IdUsuario FROM Usuarios WHERE Email = @email AND Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Usuario usuariobuscado = new Usuario
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr[1].ToString(),
                            Senha = rdr[2].ToString(),
                            IdUsuario = Convert.ToInt32(rdr[3])
                        };
                        return usuariobuscado;
                    }
                    return null;
                }
            }
        }

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
