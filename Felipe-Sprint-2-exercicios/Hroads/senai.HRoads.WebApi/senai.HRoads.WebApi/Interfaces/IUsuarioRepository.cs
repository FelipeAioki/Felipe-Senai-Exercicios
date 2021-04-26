using senai.HRoads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRoads.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cria uma lista de todos os usuarios
        /// </summary>
        /// <returns></returns>
        List<usuarioDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario"></param>
        void Cadastrar(usuarioDomain novoUsuario);
    }
}
