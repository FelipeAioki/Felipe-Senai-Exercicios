using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Controller responsavel pelos EndPoints (URL'S), referente aos funcionarios

namespace Senai.Peoples.WebApi.Controllers
{
    //Define que o tipo de respota API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/API/'nomeController'
    [Route("api/[controller]")]
    [ApiController]
    public class funcionariosController : ControllerBase
    {
        //Objeto chamado _funcionariorepository que irá receber todos os metodos definidos na interface IFuncionariosRepository
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public funcionariosController()
        {
            _funcionarioRepository = new funcionarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<funcionariosDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            return Ok(listaFuncionarios);
        }
        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            funcionariosDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);
            if (funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionario encontrado!");
            }
            return Ok(funcionarioBuscado);
        }


        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, funcionariosDomain funcionarioAtualiado)
        {
            //Faz a chamada para o metodo atualizarIdUrl passando os parametros
            _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualiado);

            //Retorna um status code 204
            return StatusCode(204);
        }


        //Cadastra um novo funcionario
        [HttpPost]
        public IActionResult Post(funcionariosDomain novoFuncionario)
        {
            //Faz a chamada para o metodo cadastrar
            _funcionarioRepository.Cadastrar(novoFuncionario);

            //Retorna um status code 201 - Created
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
