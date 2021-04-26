using senai.HRoads.WebApi.Domains;
using senai.HRoads.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRoads.WebApi.Repositories
{
    public class tipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        private string stringConexao = "Data Source =DESKTOP-5SR3EMT; initial catalog=Senai_Hroads_Manha; user id=sa; pwd=6228";
        
        /// <summary>
        /// Cria um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade"></param>
        public void Cadastrar(tipoHabilidadeDomain novoTipoHabilidade)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TipoHabilidades(Nome) VALUES(@Nome )";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoTipoHabilidade.nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a querry
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns></returns>
        public List<tipoHabilidadeDomain> ListarTodos()
        {
            List<tipoHabilidadeDomain> listaTipoHabilidades = new List<tipoHabilidadeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT Nome FROM tipoHabilidades";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        tipoHabilidadeDomain tipoHabilidade = new tipoHabilidadeDomain()
                        {
                            nome = rdr[0].ToString()

                        };
                        listaTipoHabilidades.Add(tipoHabilidade);
                    }
                }
                return listaTipoHabilidades;
            }
        }
    }
}
