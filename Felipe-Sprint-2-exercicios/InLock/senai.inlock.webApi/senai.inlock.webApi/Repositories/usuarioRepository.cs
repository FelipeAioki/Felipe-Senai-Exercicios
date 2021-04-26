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
        private string stringConexao = "Data Source =DESKTOP-5SR3EMT; initial catalog=InLock; user id=sa; pwd=6228";
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
                string querrySelectAll = "SELECT IdUsuario ,Email, Senha, Titulo AS Permissao FROM Usuario U INNER JOIN TipoUsuario TU ON u.IdTipoUsuario = TU.IdTipoUsuario WHERE Email = @email AND Senha = @senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        usuarioDomain usuario = new usuarioDomain()
                        {
                            Email = rdr[0].ToString(),
                            Senha = rdr[1].ToString()

                        };
                        listaUsuario.Add(usuario);
                    }
                }
                return listaUsuario;
            }
        }

        public usuarioDomain buscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdUsuario, TU.IdTipoUsuario ,Email, Senha, Titulo AS Permissao FROM Usuario U INNER JOIN TipoUsuario TU ON u.IdTipoUsuario = TU.IdTipoUsuario WHERE Email = @email AND Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuarioDomain usuariobuscado = new usuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            Email = rdr[2].ToString(),
                            Senha = rdr[3].ToString(),
                            Permissao = rdr[4].ToString(),
                        };
                        return usuariobuscado;
                    }
                    return null;
                }
            }
        }
    }
}
