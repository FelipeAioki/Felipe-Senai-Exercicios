using senai.HRoads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRoads.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cria uma lista de todos os Tipos de usuarios
        /// </summary>
        /// <returns></returns>
        List<tipoUsuarioDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        void Cadastrar(tipoUsuarioDomain novoTipoUsuario);
    }
}
