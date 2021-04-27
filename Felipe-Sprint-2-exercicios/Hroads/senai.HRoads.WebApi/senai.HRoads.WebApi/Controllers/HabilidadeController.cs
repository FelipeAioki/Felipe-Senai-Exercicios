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
    public class HabilidadeController : ControllerBase
    {
        /// <summary>
        /// Obejto _habilidadeRepository irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        /// <summary>
        /// instancia o objeto _habilidadeRepository para que haja uma referência nos métodos implememtados no repositório HabilidadeRepository
        /// </summary>
        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Uma lista de Habilidades  e um status code 200 - ok </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_habilidadeRepository.Listar());
        }

        /// <summary>
        /// Busca a Habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id da habiliade que será buscada</param>
        /// <returns> a habilidade encontrada e um status code 200 - ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            //return ex: reposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.BuscarId(id));
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="NovaHabilidade">objeto NovaHabilidade que será cadastrada</param>
        /// <returns>um statud code 201- Created</returns>
        [HttpPost]
        public IActionResult Post(Habilidade NovaHabilidade)

        {
            //faza a chamada para o método 
            _habilidadeRepository.Cadastrar(NovaHabilidade);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza a habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será atualizada</param>
        /// <param name="HabilidadeAtualizada">objeto HabilidadeAtualizada com as novas informações</param>
        /// <returns>um  status code 204 - no Content </returns> 
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade HabilidadeAtualizada)
        {
            //Faz a chamada para o método
            _habilidadeRepository.Atualizar(id, HabilidadeAtualizada);

            //retorna um status code 
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma habiliadde existente
        /// </summary>
        /// <param name="id">id da habilidade que sera deletada</param>
        /// <returns>um status code 204 -  no Cotent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _habilidadeRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        ///  Lista todos as habilidades e seus respectivos TiposHabilidades
        /// </summary>
        /// <returns>lista de Habilidades com os TiposHabilidades e um status code 200 - ok </returns>
        [HttpGet("TipoHabilidade")]
        public IActionResult GetPersonagem()
        {
            //retorna a repsosta da requisição fazendo a chamda para o método
            return Ok(_habilidadeRepository.ListarHabilidades());
        }
    }
}
