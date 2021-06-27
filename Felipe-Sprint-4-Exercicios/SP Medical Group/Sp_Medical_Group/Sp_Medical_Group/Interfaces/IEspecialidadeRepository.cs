using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todas as Especialidades
        /// </summary>
        /// <returns>Lista de Especialidades</returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Busca sua Especialidade através do seu id
        /// </summary>
        /// <param name="id">Id Especialidade será busacado</param>
        /// <returns> Uma Especialidade buscada</returns>
        Consulta BuscarId(int id);

        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="NovaEspecialidade">Objeto NovaEspecialidade que será cadastrada</param>
        void Cadastrar(Especialidade NovaEspecialidade);

        /// <summary>
        /// Atualiza uma Especialidade existente
        /// </summary>
        /// <param name="id">id da Especialidade que será atualizada</param>
        /// <param name="ConsultaAtualizada">Objeto EspecialidadeAtualizada com as novas Informações</param>
        void Atualizar(int id, Especialidade EspecialidadeAtualizada);

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="id">id da Especialidade que sera deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as Especialidades
        /// </summary>
        /// <returns>Retorna uma lista de Especialidades</returns>
        List<Especialidade> ListarEspecialidades();
    }
}
