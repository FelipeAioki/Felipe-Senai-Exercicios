using senai.HRoads.WebApi.Domains;
using senai.HRoads.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRoads.WebApi.Repositories
{
    public class tipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source =DESKTOP-5SR3EMT; initial catalog=Senai_Hroads_Manha; user id=sa; pwd=6228";
        
        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        public void Cadastrar(tipoUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TipoUsuario(titulo) VALUES(@titulo )";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", novoTipoUsuario.titulo);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a querry
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns></returns>
        public List<tipoUsuarioDomain> ListarTodos()
        {
            List<tipoUsuarioDomain> listaTipoUsuarios = new List<tipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT titulo FROM tipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        tipoUsuarioDomain tipoUsuario = new tipoUsuarioDomain()
                        {
                            titulo = rdr[0].ToString()

                        };
                        listaTipoUsuarios.Add(tipoUsuario);
                    }
                }
                return listaTipoUsuarios;
            }
        }
    }
}
