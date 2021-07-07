using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos Medico
        /// </summary>
        /// <returns>Lista de Medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca Medico através do seu id
        /// </summary>
        /// <param name="id">Id Medico será busacado</param>
        /// <returns> Um Medico buscado</returns>
        Medico BuscarId(int id);


        /// <summary>
        /// Cadastra um novo Medico
        /// </summary>
        /// <param name="NovoMedico">Objeto NovoMedico que será cadastrado</param>
        void Cadastrar(Medico NovoMedico);

        /// <summary>
        /// Atualiza um Medico existente
        /// </summary>
        /// <param name="id">id do Medico que será atualizado</param>
        /// <param name="MedicoAtualizado">Objeto MedicoAtualizado com as novas Informações</param>
        void Atualizar(int id, Medico MedicoAtualizado);

        /// <summary>
        /// Deleta um Medico existente
        /// </summary>
        /// <param name="id">id do Medico que sera deletado</param>
        void Deletar(int id);

        public List<Consulta> ListarTodosIdMedico(int IdMedico);

        /// <summary>
        /// Listar todas os Medicos
        /// </summary>
        /// <returns>Retorna uma lista de Medicos</returns>
        List<Medico> ListarMedicos();
    }
}
