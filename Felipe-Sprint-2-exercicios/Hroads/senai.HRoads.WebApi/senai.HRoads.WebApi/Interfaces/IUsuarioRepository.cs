using Senai.HRoads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.HRoads.WebApi.Interfaces
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
        Usuario buscarPorEmailSenha(string email, string senha);
    }
}
