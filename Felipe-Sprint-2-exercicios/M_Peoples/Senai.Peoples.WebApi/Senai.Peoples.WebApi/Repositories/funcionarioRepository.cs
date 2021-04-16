using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    //Classe responsalvel pelo repositorio dos funcionarios
    public class funcionarioRepository : IFuncionarioRepository
    {
        //String para fazer a conexão com o banco de dados
        //Data source = Nome do servidor
        //initial catalog = Nome do banco de dados
        //user id = Login --- Fazendo a autenticação com usuario e senha
        //pwd = Senha
        //Integrated security =true --- Fazendo autenticação com o usuario do sistema(Windows)
        private string stringConexao = "Data Source=DESKTOP-5SR3EMT; initial catalog=M_Peoples; user id=sa; pwd=6228";
        public void AtualizarIdCorpo(funcionariosDomain funcionarios)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, funcionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Funcionarios SET Nome = @nome WHERE idNome = @ID;UPDATE Funcionarios SET Sobrenome = @Sobrenome WHERE idNome = @ID;UPDATE Funcionarios SET Nascimento = @nascimento WHERE idNome = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Passando os valores para os parametros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionarios.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.sobrenome);
                    cmd.Parameters.AddWithValue("@Nascimento", funcionarios.nascimento);


                    //Abre a conexão
                    con.Open();

                    //Execulta o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public funcionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idNome, Nome, Sobrenome, Nascimento FROM Funcionarios WHERE IdNome = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    //executa a query que armazena os dados do select no rdr
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        funcionariosDomain funcionarioBuscado = new funcionariosDomain
                        {
                            idNome = Convert.ToInt32(rdr["idNome"]),
                            nome = rdr["Nome"].ToString(),
                            sobrenome = rdr["Sobrenome"].ToString(),
                            nascimento = rdr["Nascimento"].ToString()
                        };
                    //Retorna o funcionario buscado com os dados obtidos
                    return funcionarioBuscado;
                    }
                //Se não, retorna null
                return null;
                }
            }
        }

        public void Cadastrar(funcionariosDomain novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Fazemos o comando que será executado mais a frente
                //não fazer dessa maneira pois pode causar o efeito Joana D'ark (SQL INJECTION)
                //string queryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome, Nascimento) VALUES('"+novoFuncionario.nome+"','"+novoFuncionario.sobrenome+"','"+novoFuncionario.nascimento+"');";

                string queryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome, Nascimento) VALUES(@Nome, @Sobrenome, @Nascimento);";
                //Declara o comando que será executada + a conexão do SQL
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Criamos um parametro aos dados colocados acima
                    //Passa um valor para os parametros correspondentes
                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.sobrenome);
                    cmd.Parameters.AddWithValue("@Nascimento", novoFuncionario.nascimento);


                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a querry
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            //Declara a sql connection passando a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada passando o id como parametro
                string queryDelete = "DELETE FROM Funcionarios WHERE idNome = @ID";

                //Declara o sql commando(cmd) passando a query que será executada e tambem a conexão
                using(SqlCommand cmd = new SqlCommand (queryDelete,con))
                {
                    //Define o valor do id recebino no metodo, no parametro ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<funcionariosDomain> ListarTodos()
        {
            //Cria uma nova lista com o nome listafuncionarios, onde serão armazenados os dados
            List<funcionariosDomain> listafuncionarios = new List<funcionariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a querry a ser executada no banco de dados (codico vai ser executado no sql quando ela for chamada)
                string querrySelectAll = "Select * From Funcionarios";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr para percorrer a tabela do sql
                SqlDataReader rdr;

                //Declara o sqlcommand cmd passando a querry e a conexão como parametro que serão exeutados
                using (SqlCommand cmd = new SqlCommand(querrySelectAll, con))
                {
                    // Executa a querry e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros a serem lidos, o laço se repete
                    while (rdr.Read())
                    {
                        //instacia um objeto funcionario do tipo funcionarioDomain
                        funcionariosDomain funcionario = new funcionariosDomain()
                        {
                            //Atribui ao funcionario dados, conforme tinha colocado no funcionariosDomain
                            idNome = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString(),
                            sobrenome = rdr[2].ToString(),
                            nascimento = rdr[3].ToString()
                        };

                        listafuncionarios.Add(funcionario);
                    }
                }
            }
            //Retorna a lista de usuarios que fiz acima
            return listafuncionarios;
        }
    }
}
