using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class tipoUsuarioRepository : ITipoUsuarioRepository
    {

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, TipoUsuario TipoUsuarioAtualizado)
        {
            //busca uma classe através do Id
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            //verifica se o nome da classe foi informada
            if (TipoUsuarioAtualizado.NomeTipo != null)
            {
                //atribui o valor ao campo existente    
                TipoUsuarioBuscado.NomeTipo = TipoUsuarioAtualizado.NomeTipo;
            }

            //atualiza o campo buscado
            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            //salva as informações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario TipoUsuarioBuscada = ctx.TipoUsuarios.Find(id);

            //remove a classe buscada
            ctx.TipoUsuarios.Remove(TipoUsuarioBuscada);

            //salvas as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public List<TipoUsuario> ListarTipoUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
