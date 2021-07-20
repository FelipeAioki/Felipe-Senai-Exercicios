using Sp_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos Paciente
        /// </summary>
        /// <returns>Lista de Paciente</returns>
        List<Paciente> Listar();

        /// <summary>
        /// Busca Paciente através do seu id
        /// </summary>
        /// <param name="id">Id Paciente será busacado</param>
        /// <returns> Um Paciente buscado</returns>
        Paciente BuscarId(int id);

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="NovoPaciente">Objeto NovoPaciente que será cadastrado</param>
        void Cadastrar(Paciente NovoPaciente);

        /// <summary>
        /// Atualiza um Paciente existente
        /// </summary>
        /// <param name="id">id do Paciente que será atualizado</param>
        /// <param name="PacienteAtualizado">Objeto PacienteAtualizado com as novas Informações</param>
        void Atualizar(int id, Paciente PacienteAtualizado);

        /// <summary>
        /// Deleta um Paciente existente
        /// </summary>
        /// <param name="id">id do Paciente que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todos os Paciente
        /// </summary>
        /// <returns>Retorna uma lista de Pacientes</returns>
        List<Paciente> ListarPaciente();
    }
}
