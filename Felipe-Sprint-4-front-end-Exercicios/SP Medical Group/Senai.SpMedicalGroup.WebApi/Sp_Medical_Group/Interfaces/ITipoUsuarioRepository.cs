using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Uma lista de usuarios
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario existente
        /// </summary>
        /// <param name="id">id do TipoUsuario que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado com as novas Informações</param>
        void Atualizar(int id, TipoUsuario TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="id">id do TipoUsuario que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas os TiposUsuario
        /// </summary>
        /// <returns>Retorna uma lista de TiposUsuario</returns>
        List<TipoUsuario> ListarTipoUsuario();
    }
}
