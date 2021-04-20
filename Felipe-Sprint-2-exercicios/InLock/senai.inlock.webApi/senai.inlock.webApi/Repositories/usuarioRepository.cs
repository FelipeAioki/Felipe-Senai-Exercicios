using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace senai.inlock.webApi.Repositories
{
    public class usuarioRepository : IUsuarioRepository 
    {
        private string stringConexao = "Data Source =DESKTOP-OL23F2H\\SQLEXPRESS; initial catalog=InLock; user id=sa; pwd=senai@132";
        /// <summary>
        /// Método de Cadastrar um novo jogo
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// 
        public void Cadastrar(usuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(IdTipoUsuario,Email, Senha) VALUES(@IdTipoUsuario ,@Email ,@Senha)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a querry
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método de listar todos os Jogos
        /// </summary>
        /// <returns>Uma Lista de jogos</returns>
        public List<usuarioDomain> Listar()
        {
            List<usuarioDomain> listaUsuario = new List<usuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdTipoUsuario ,IdUsuario, Email, Senha FROM Usuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuarioDomain usuario = new usuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            IdUsuario = Convert.ToInt32(rdr[1]),
                            Email = rdr[2].ToString(),
                            Senha = rdr[3].ToString(),

                        };
                        listaUsuario.Add(usuario);
                    }
                }
                return listaUsuario;
            }
        }
    }
}
