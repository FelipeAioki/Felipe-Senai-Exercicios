using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.HRoads.WebApi.Domains;
using Senai.HRoads.WebApi.Interfaces;
using Senai.HRoads.WebApi.Repositories;
using SENAI_Hroads_API.Interfaces;
using SENAI_Hroads_API.Repositories;

namespace SENAI_Hroads_API.Controllers
{
    //define que o tipo de reposta da API será no formato JSON
    [Produces("application/json")]
    //define que a rota de uma requisição será no formato domínio/api/NomeController
    //ex: http://localhost:5000/api/classes
    [Route("api/[controller]")]
    //Define que é um controlador de API
    [ApiController]
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Obejto _classesRepository irá receber todos os métodos definidos na interface IClassesRepository
        /// </summary>
        private IClassesRepository _classeRepository { get; set; }


        /// <summary>
        /// instancia o objeto _classesRepository para que haja uma referência nos métodos implememtados no repositório ClassesRepository
        /// </summary>
        public ClassesController()
        {
            _classeRepository = new ClassesRepository();
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de Classes  e um status code 200 - ok </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_classeRepository.Listar());
        }

        /// <summary>
        /// Busca a classe pelo seu id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns> a classe encontrada e um status code 200 - ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            //return ex: reposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.BuscarId(id));
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="NovaClasse">objeto NovaClasse que será cadastrada</param>
        /// <returns>um statud code 201- Created</returns>
        [HttpPost]
        public IActionResult Post(Classes NovaClasse)

        {
            //faza a chamada para o método 
            _classeRepository.Cadastrar(NovaClasse);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza a classe existente
        /// </summary>
        /// <param name="id">Id da classe que será atualizada</param>
        /// <param name="ClasseAtualizada">objeto ClasseAtualizada com as novas informações</param>
        /// <returns>um  status code 204 - no Content </returns> 
        [HttpPut("{id}")] 
        public IActionResult Put(int id, Classes ClasseAtualizada)
        {
            //Faz a chamada para o método
            _classeRepository.Atualizar(id, ClasseAtualizada);

            //retorna um status code 
            return StatusCode(204);
        }


        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">id da classe que sera deletada</param>
        /// <returns>um status code 204 -  no Cotent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _classeRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }
            

        /// <summary>
        ///  Lista todos as classes e seus respectivos personagens
        /// </summary>
        /// <returns>lista de classes com os personagens e um status code 200 - ok </returns>
        [HttpGet("personagem")]
        public IActionResult GetPersonagem()
        {
            //retorna a repsosta da requisição fazendo a chamda para o método
            return Ok(_classeRepository.ListarClasses());
        }

    }
}
