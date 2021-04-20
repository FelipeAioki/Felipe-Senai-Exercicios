using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class jogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source =DESKTOP-OL23F2H\\SQLEXPRESS; initial catalog=InLock; user id=sa; pwd=senai@132";
        /// <summary>
        /// Método de Cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// 
        public void Cadastrar(jogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(NomeJogo, idEstudio, Descricao, Lancamento, Valor) VALUES( @Nome, @IdEstudio, @Descricao, @Lancamento, @Valor);";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.descrição);
                    cmd.Parameters.AddWithValue("@Lancamento", novoJogo.lancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.valor);

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
        public List<jogoDomain> ListarTodos()
        {
            List<jogoDomain> listaJogos = new List<jogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querrySelectAll = "SELECT IdJogo ,NomeJogo , NomeEstudio, Descricao, valor, Lancamento FROM Jogo JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand (querrySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        jogoDomain jogo = new jogoDomain()
                        {
                            idJogo     = Convert.ToInt32(rdr[0]),
                            nome       = rdr[1].ToString(),
                            estudio    = rdr[2].ToString(),
                            descrição  = rdr[3].ToString(),
                            valor      = Convert.ToInt32(rdr[4]),
                            lancamento = Convert.ToDateTime(rdr[5]),
                        };
                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }

    }
}
