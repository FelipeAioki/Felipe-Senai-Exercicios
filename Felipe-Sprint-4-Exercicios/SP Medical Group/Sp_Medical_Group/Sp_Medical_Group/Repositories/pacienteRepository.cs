using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class pacienteRepository : IPacienteRepository
    {

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Paciente PacienteAtualizado)
        {
            //busca uma classe através do Id
            Paciente PacienteBuscado = ctx.Pacientes.Find(id);

            //verifica se o nome da classe foi informada
            if (PacienteAtualizado.Nome != null)
            {
                //atribui o valor ao campo existente    
                PacienteBuscado.Nome = PacienteAtualizado.Nome;
            }

            //atualiza o campo buscado
            ctx.Pacientes.Update(PacienteBuscado);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public Paciente BuscarId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(c => c.IdPaciente == id);
        }

        public void Cadastrar(Paciente NovoPaciente)
        {
            ctx.Pacientes.Add(NovoPaciente);

            //salva as informações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }

        public List<Paciente> ListarPaciente()
        {
            throw new NotImplementedException();
        }
    }
}
