using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class medicoRepository : IMedicoRepository
    {

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
    }
}
