using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.HRoads.WebApi.Domains;

namespace SENAI_Hroads_API.Interfaces
{   /// <summary>
    /// Interface pela ClassesRepository
    /// </summary>
    interface IClassesRepository
    {
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Lista de classes</returns>
        List<Classes> Listar();

        /// <summary>
        /// Busca sua classe através do seu id
        /// </summary>
        /// <param name="id">Id classe será busacado</param>
        /// <returns> Uma classe buscada</returns>
        Classes BuscarId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="NovaClasse">Objeto NovaClasse que será cadastrada</param>
        void Cadastrar(Classes NovaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">id da classe que será atualizada</param>
        /// <param name="ClasseAtualizada">Objeto ClasseAtualizada com as novas Informações</param>
        void Atualizar(int id, Classes ClasseAtualizada);

        /// <summary>
        /// Deleta uma Classe existente
        /// </summary>
        /// <param name="id">id da classe que sera deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as classes com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de classes com seus personagens</returns>
        List<Classes> ListarClasses();
    }
}
