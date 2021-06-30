using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as Consultas
        /// </summary>
        /// <returns>Lista deConsulta</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Busca sua Consulta através do seu id
        /// </summary>
        /// <param name="id">Id Consulta será busacado</param>
        /// <returns> Uma Consulta buscada</returns>
        Consulta BuscarId(int id);

        Consulta BuscarIdPaciente(int idPaciente);

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="NovaConsulta">Objeto NovaConsulta que será cadastrada</param>
        void Cadastrar(Consulta NovaConsulta);

        /// <summary>
        /// Atualiza uma Consulta existente
        /// </summary>
        /// <param name="id">id da Consulta que será atualizada</param>
        /// <param name="ConsultaAtualizada">Objeto ConsultaAtualizada com as novas Informações</param>
        void Atualizar(int id, Consulta ConsultaAtualizada);

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="id">id da Consulta que sera deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as Consulta com seus pacientes
        /// </summary>
        /// <returns>Retorna uma lista de Consulta com seus pacientes</returns>
    }
}
