using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface == O que vai ser feito
    /// Repositorio == Como vai ser feito
    /// </summary>
    public interface IFuncionarioRepository
    {
        //TipoDeRetorno NomeMetodo (Paramêtros);
        //Void          Cadastrar  ();
        //Retorna todos os funcionarios
        List<funcionariosDomain> ListarTodos();


        //Busca um funcionario atraves do id
        funcionariosDomain BuscarPorId(int id);

        //Cadastra um funcionario com os atributos contidos no domain
        void Cadastrar(funcionariosDomain novoFuncionario);

        //Atualiza o funcionario ultilizando o Id pelo corpo da requisição
        void AtualizarIdCorpo(funcionariosDomain funcionarios);

        //Atualiza o funcionario ultilizando o id pela URL
        void AtualizarIdUrl(int id, funcionariosDomain funcionarios);

        //Deleta um funcionario pela URL
        void Deletar(int id);
    }
}
