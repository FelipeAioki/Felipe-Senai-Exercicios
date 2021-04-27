using Senai.HRoads.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.HRoads.WebApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Uma lista de todas os tipos de Habilidades
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        List<TipoHabilidade> Listar();

        /// <summary>
        /// Cadastra um novo tipo de Habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade"></param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);
    }
}
