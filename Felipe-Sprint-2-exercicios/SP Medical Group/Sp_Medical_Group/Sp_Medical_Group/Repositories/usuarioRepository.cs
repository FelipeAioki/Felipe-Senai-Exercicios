using Sp_Medical_Group.Contexts;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Repositories
{
    public class usuarioRepository : IUsuarioRepository
    {

        /// <summary>
        /// Objeto de contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            //busca uma classe através do Id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            //verifica se o nome da classe foi informada
            if (UsuarioAtualizado.NomeUsuario != null)
            {
                //atribui o valor ao campo existente    
                UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
            }

            //atualiza o campo buscado
            ctx.Usuarios.Update(UsuarioBuscado);

            //salva as alterações para serem salvas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario buscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
