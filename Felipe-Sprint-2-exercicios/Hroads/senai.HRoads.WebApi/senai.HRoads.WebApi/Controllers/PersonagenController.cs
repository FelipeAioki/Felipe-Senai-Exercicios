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
    //ex: http://localhost:5000/api/habilidade
    [Route("api/[controller]")]
    //Define que é um controlador de API
    [ApiController]
    public class PersonagenController : ControllerBase
    {
        /// <summary>
        /// Obejto _habilidadeRepository irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IPersonagenRepository _personagenRepository { get; set; }

        /// <summary>
        /// instancia o objeto _personagenRepository para que haja uma referência nos métodos implememtados no repositório PersonagenRepository
        /// </summary>
        public PersonagenController()
        {
            _personagenRepository = new PersonagenRepository();
        }

        /// <summary>
        /// Lista todos os Personagens
        /// </summary>
        /// <returns>Uma lista de personagens  e um status code 200 - ok </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_personagenRepository.Listar());
        }

        /// <summary>
        /// Busca o Personagem pelo seu id
        /// </summary>
        /// <param name="id">Id do Personagem que será buscada</param>
        /// <returns> o personagem encontrado e um status code 200 - ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            //return ex: reposta da requisição fazendo a chamada para o método
            return Ok(_personagenRepository.BuscarId(id));
        }

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="NovoPersonagem">objeto NovoPersonagem que será cadastrada</param>
        /// <returns>um statud code 201- Created</returns>
        [HttpPost]
        public IActionResult Post(Personagen NovoPersonagem)

        {
            //faza a chamada para o método 
            _personagenRepository.Cadastrar(NovoPersonagem);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza o personagem existente
        /// </summary>
        /// <param name="id">Id do personagem que será atualizadp</param>
        /// <param name="PersonagemAtualizado">objeto PersonagemAtualizado com as novas informações</param>
        /// <returns>um  status code 204 - no Content </returns> 
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagen PersonagemAtualizado)
        {
            //Faz a chamada para o método
            _personagenRepository.Atualizar(id, PersonagemAtualizado);

            //retorna um status code 
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">id do Personagem que sera deletado</param>
        /// <returns>um status code 204 -  no Cotent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _personagenRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        ///  Lista todos os Personagens e suas respectivas Classes
        /// </summary>
        /// <returns>lista de Personagens com as Classes e um status code 200 - ok </returns>
        [HttpGet("Classes")]
        public IActionResult GetPersonagem()
        {
            //retorna a repsosta da requisição fazendo a chamda para o método
            return Ok(_personagenRepository.ListarPersonagen());
        }
    }
}
