using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class consultaRepository : IConsultaRepository
    {

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
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == idPaciente);
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
    }
}
