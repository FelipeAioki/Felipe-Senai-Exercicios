using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class clínicaRepository : IClínicaRepository
    {

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Clínica ClínicaAtualizada)
        {
            //busca uma classe através do Id
            Clínica ClínicaBuscada = ctx.Clínicas.Find(id);

            //verifica se o nome da classe foi informada
            if (ClínicaAtualizada.Nome != null)
            {
                //atribui o valor ao campo existente    
                ClínicaBuscada.Nome = ClínicaAtualizada.Nome;
            }

            //atualiza o campo buscado
            ctx.Clínicas.Update(ClínicaBuscada);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public Clínica BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clínica NovaClasse)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clínica> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Clínica> ListarClinica()
        {
            throw new NotImplementedException();
        }
    }
}
