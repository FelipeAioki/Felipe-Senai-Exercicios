using senai.HRoads.WebApi.Domains;
using senai.HRoads.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRoads.WebApi.Repositories
{
    public class usuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source =DESKTOP-5SR3EMT; initial catalog=Senai_Hroads_Manha; user id=sa; pwd=6228";
        
        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario"></param>
        public void Cadastrar(usuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(Email, Senha) VALUES(@Email ,@Senha)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.senha);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a querry
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os usuarios com email e senha
        /// </summary>
        /// <returns></returns>
        public List<usuarioDomain> ListarTodos()
        {
            List<usuarioDomain> listaUsuarios = new List<usuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT Email, Senha FROM Usuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        usuarioDomain usuario = new usuarioDomain()
                        {
                        email = rdr[0].ToString(),
                        senha = rdr[1].ToString()

                    };
                        listaUsuarios.Add(usuario);
                    }
                }
                return listaUsuarios;
            }
        }
    }
}
