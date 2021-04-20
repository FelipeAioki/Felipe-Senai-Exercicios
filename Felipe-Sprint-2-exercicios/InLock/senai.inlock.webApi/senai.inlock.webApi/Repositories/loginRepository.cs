using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class loginRepository : ILoginRepository
    {
        private string stringConexao = "Data Source =DESKTOP-OL23F2H\\SQLEXPRESS; initial catalog=InLock; user id=sa; pwd=senai@132";
        /// <summary>
        /// Método de Cadastrar um novo jogo
        /// </summary>
        /// <param name="novoLogin"></param>
        /// 
        public void Cadastrar(loginDomain novoLogin)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TipoUsuario(Titulo) VALUES( @Titulo);";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoLogin.Titulo);

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
        /// <returns>Lista de tipos de Usuarios</returns>
        public List<loginDomain> Listar()
        {
            List<loginDomain> listaTipoUsuarios = new List<loginDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdTipoUsuario,Titulo FROM TipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        loginDomain tipoUsuario = new loginDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString(),
                        };
                        listaTipoUsuarios.Add(tipoUsuario);
                    }
                }
            }
            return listaTipoUsuarios;
        }
    }
}
