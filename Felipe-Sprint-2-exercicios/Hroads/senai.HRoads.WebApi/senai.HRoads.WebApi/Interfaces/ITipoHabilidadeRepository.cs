using senai.HRoads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRoads.WebApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Cria uma lista de todos os tipos de habilidades
        /// </summary>
        /// <returns></returns>
        List<tipoHabilidadeDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade"></param>
        void Cadastrar(tipoHabilidadeDomain novoTipoHabilidade);
    }
}
