using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.HRoads.WebApi.Domains;

namespace Senai.HRoads.WebApi.Interfaces
{       
        /// <summary>
        /// Interface pelo PersonagenRepository
        /// </summary>
    interface IPersonagenRepository
    { 
       
        /// <summary>
        /// Lista todos Personagens
        /// </summary>
        /// <returns>Lista de Personagens</returns>
        List<Personagen> Listar();


        /// <summary>
        /// Busca um Personagem através do seu id
        /// </summary>
        /// <param name="id">Id do personagem que será buscado</param>
        /// <returns> Um Personagem buscado</returns>
        Personagen BuscarId(int id);

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="NovoPersonagem">Objeto NovoPersonagem que será cadastrado</param>
        void Cadastrar(Personagen NovoPersonagem);


        /// <summary>
        /// Atualiza um Personagem existente
        /// </summary>
        /// <param name="id">id do persongem que será atualizado</param>
        /// <param name="PersonagenAtualizado">Objeto PersonagenAtualizado com as novas Informações</param>
        void Atualizar(int id, Personagen PersonagenAtualizado);

        /// <summary>
        /// Deleta um Personagem existente
        /// </summary>
        /// <param name="id">id do personagem que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as classes com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de personagens com suas classes</returns>
        List<Personagen> ListarPersonagen();
    }
}
