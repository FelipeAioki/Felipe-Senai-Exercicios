using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Uma lista de usuarios
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        void Cadastrar(Usuario novoUsuario);

        //Busca um usuario pelo email e a senha
        Usuario buscarPorEmailSenha(string email, string senha);

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="id">id do Usuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto UsuarioAtualizado com as novas Informações</param>
        void Atualizar(int id, Usuario UsuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="id">id do Usuario que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas os Usuarios
        /// </summary>
        /// <returns>Retorna uma lista de Usuarios</returns>
        List<Usuario> ListarUsuarios();
    }
}
