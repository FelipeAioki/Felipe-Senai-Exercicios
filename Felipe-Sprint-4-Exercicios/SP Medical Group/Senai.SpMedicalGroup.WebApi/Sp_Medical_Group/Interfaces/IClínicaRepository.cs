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
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Lista de clinicas</returns>
        List<Clínica> Listar();

        /// <summary>
        /// Busca sua clinicas através do seu id
        /// </summary>
        /// <param name="id">Id clinicas será busacado</param>
        /// <returns> Uma clinicas buscada</returns>
        Clínica BuscarId(int id);

        /// <summary>
        /// Cadastra uma nova clinicas
        /// </summary>
        /// <param name="Novaclinicas">Objeto Novaclinicas que será cadastrada</param>
        void Cadastrar(Clínica NovaClinica);

        /// <summary>
        /// Atualiza uma clinicas existente
        /// </summary>
        /// <param name="id">id da clinicas que será atualizada</param>
        /// <param name="clinicasAtualizada">Objeto clinicasAtualizada com as novas Informações</param>
        void Atualizar(int id, Clínica ClínicaAtualizada);

        /// <summary>
        /// Deleta uma clinicas existente
        /// </summary>
        /// <param name="id">id da clinicas que sera deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as clinicas com seus personagens
        /// </summary>
        /// <returns>Retorna uma lista de clinicas</returns>
        List<Clínica> ListarClínica();
    }
}
