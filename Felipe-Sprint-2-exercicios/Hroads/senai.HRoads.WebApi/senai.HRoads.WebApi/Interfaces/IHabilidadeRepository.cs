using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.HRoads.WebApi.Domains;

namespace SENAI_Hroads_API.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca sua habilidade através do seu id
        /// </summary>
        /// <param name="id">Id habilidade será busacado</param>
        /// <returns> Uma habilidade buscada</returns>
        Habilidade BuscarId(int id);

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="NovaHabiliade">Objeto NovaHabiliade que será cadastrada</param>
        void Cadastrar(Habilidade NovaHabiliade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que será atualizada</param>
        /// <param name="HabilidadeAtualizada">Objeto HabilidadeAtualizada com as novas Informações</param>
        void Atualizar(int id, Habilidade HabilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que sera deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as habilidades com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de habilidades com seus personagens</returns>
        List<Habilidade> ListarHabilidades();
    }
}
