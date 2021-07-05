using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class consultaRepository : IConsultaRepository
    {
        //private string stringConexao = @"Data Source=FELIPE-PC\SQLEXPRESS; initial catalog=SP_Medical_Group; user id=sa; pwd=6228";
        private string stringConexao = @"Data Source = LAB08DESK601\SQLEXPRESS; initial catalog = SP_Medical_Group; Integrated Security = true;";
        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Consulta ConsultaAtualizada)
        {
            //busca uma classe através do Id
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            //verifica se o nome da classe foi informada
            if (ConsultaAtualizada.Situação != null)
            {
                //atribui o valor ao campo existente    
                ConsultaBuscada.Situação = ConsultaAtualizada.Situação;
            }

            //atualiza o campo buscado
            ctx.Consultas.Update(ConsultaBuscada);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public Consulta BuscarId(int id)
        {
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == id);
        }

        public Consulta BuscarIdPaciente(int idPaciente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT Especialidades.Nome AS 'Especialidade', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação, Clínica.Endereço AS 'Endereço' FROM Pacientes FULL OUTER JOIN Consultas ON Pacientes.IdPaciente = Consultas.IdPaciente FULL OUTER JOIN Medicos ON Medicos.IdMedico = Consultas.IdMedico FULL OUTER JOIN Especialidades ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade FULL OUTER JOIN Clínica on Clínica.IdClinica = Clínica.IdClinica  WHERE Pacientes.IdPaciente = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idPaciente);

                    //executa a query que armazena os dados do select no rdr
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Consulta consultaBuscado = new Consulta
                        {
                            Especialidade = rdr[0].ToString(),
                            Medico = rdr[1].ToString(),
                            DataDaConsulta = rdr[2].ToString(),
                            Situação = rdr[3].ToString(),
                            Endereço = rdr[4].ToString(),
                        };
                        //Retorna a consulta buscada com os dados obtidos
                        return consultaBuscado;
                    }
                    //Se não, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(Consulta NovaConsulta)
        {
            ctx.Consultas.Add(NovaConsulta);

            //salva as informações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }

        public List<Consulta> ListarTodos()
        {
            List<Consulta> listaConsultas = new List<Consulta>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT Pacientes.Nome AS 'Nome do Paciente', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação, Especialidades.Nome AS 'Nome', Clínica.Endereço FROM Pacientes FULL OUTER JOIN Consultas ON Pacientes.IdPaciente = Consultas.IdPaciente FULL OUTER JOIN Medicos ON Medicos.IdMedico = Consultas.IdMedico INNER JOIN Especialidades ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade INNER JOIN Clínica ON Clínica.IdClinica = Clínica.IdClinica;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    //executa a query que armazena os dados do select no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Consulta consultabusca = new Consulta()
                        {
                            Especialidade = rdr[4].ToString(),
                            Medico = rdr[1].ToString(),
                            DataDaConsulta = rdr[2].ToString(),
                            Situação = rdr[3].ToString(),
                            Endereço = rdr[5].ToString(),
                        };
                        listaConsultas.Add(consultabusca);
                    }
                }
            return listaConsultas;
            }
        }
    }
}
