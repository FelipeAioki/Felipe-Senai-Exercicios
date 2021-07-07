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
    public class medicoRepository : IMedicoRepository
    {
        private string stringConexao = @"Data Source = LAB08DESK601\SQLEXPRESS; initial catalog = SP_Medical_Group; Integrated Security = true;";

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Medico MedicoAtualizado)
        {
            //busca uma classe através do Id
            Medico MedicoBuscado = ctx.Medicos.Find(id);

            //verifica se o nome da classe foi informada
            if (MedicoAtualizado.Nome != null)
            {
                //atribui o valor ao campo existente    
                MedicoBuscado.Nome = MedicoAtualizado.Nome;
            }

            //atualiza o campo buscado
            ctx.Medicos.Update(MedicoBuscado);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public Medico BuscarId(int id)
        {
            return ctx.Medicos.FirstOrDefault(c => c.IdMedico == id);
        }

        public void Cadastrar(Medico NovoMedico)
        {
            ctx.Medicos.Add(NovoMedico);

            //salva as informações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Medico MedicoBuscada = ctx.Medicos.Find(id);

            //remove a classe buscada
            ctx.Medicos.Remove(MedicoBuscada);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }

        public List<Medico> ListarMedicos()
        {
            throw new NotImplementedException();
        }

        public List<Consulta> ListarTodosIdMedico(int IdMedico)
        {
            List<Consulta> listaConsultas = new List<Consulta>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT Especialidades.Nome AS 'Especialidade', Medicos.Nome AS 'Médico', Consultas.Data_da_consulta AS 'Data da Consulta', Consultas.Situação, Clínica.Endereço AS 'Endereço' FROM Pacientes FULL OUTER JOIN Consultas ON Pacientes.IdPaciente = Consultas.IdPaciente FULL OUTER JOIN Medicos ON Medicos.IdMedico = Consultas.IdMedico FULL OUTER JOIN Especialidades ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade FULL OUTER JOIN Clínica on Clínica.IdClinica = Clínica.IdClinica  WHERE Medicos.IdMedico = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    cmd.Parameters.AddWithValue("@ID", IdMedico);
                    //executa a query que armazena os dados do select no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Consulta consultabusca = new Consulta()
                        {
                            Especialidade = rdr[0].ToString(),
                            Medico = rdr[1].ToString(),
                            DataDaConsulta = rdr[2].ToString(),
                            Situação = rdr[3].ToString(),
                            Endereço = rdr[4].ToString(),
                        };
                        listaConsultas.Add(consultabusca);
                    }
                }
                return listaConsultas;
            }
        }
    }
}
