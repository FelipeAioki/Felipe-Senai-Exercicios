using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class especialidadeRepository : IEspecialidadeRepository
    {

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Especialidade EspecialidadeAtualizada)
        {
            //busca uma classe através do Id
            Especialidade EspecialidadeBuscada = ctx.Especialidades.Find(id);

            //verifica se o nome da classe foi informada
            if (EspecialidadeAtualizada.Nome != null)
            {
                //atribui o valor ao campo existente    
                EspecialidadeBuscada.Nome = EspecialidadeAtualizada.Nome;
            }

            //atualiza o campo buscado
            ctx.Especialidades.Update(EspecialidadeBuscada);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public Consulta BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Especialidade NovaEspecialidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Especialidade> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Especialidade> ListarEspecialidades()
        {
            throw new NotImplementedException();
        }
    }
}
