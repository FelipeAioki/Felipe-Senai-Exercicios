using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IClínicaRepository
    {
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Lista de classes</returns>
        List<Clínica> Listar();

        /// <summary>
        /// Busca sua classe através do seu id
        /// </summary>
        /// <param name="id">Id classe será busacado</param>
        /// <returns> Uma classe buscada</returns>
        Clínica BuscarId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="NovaClasse">Objeto NovaClasse que será cadastrada</param>
        void Cadastrar(Clínica NovaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">id da classe que será atualizada</param>
        /// <param name="ClasseAtualizada">Objeto ClasseAtualizada com as novas Informações</param>
        void Atualizar(int id, Clínica ClínicaAtualizada);

        /// <summary>
        /// Deleta uma Classe existente
        /// </summary>
        /// <param name="id">id da classe que sera deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as classes com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de classes com seus personagens</returns>
        List<Clínica> ListarClasses();
    }
}
