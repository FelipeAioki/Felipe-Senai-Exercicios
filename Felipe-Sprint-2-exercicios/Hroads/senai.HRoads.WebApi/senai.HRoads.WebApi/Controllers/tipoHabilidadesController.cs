using Microsoft.AspNetCore.Mvc;
using Senai.HRoads.WebApi.Domains;
using Senai.HRoads.WebApi.Interfaces;
using Senai.HRoads.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.HRoads.WebApi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class tipoHabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos
        /// </summary>
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        /// <summary>
        /// Instancia o obejto para que haja a referencia nos metodos implementados no repositorio
        /// </summary>
        public tipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new tipoHabilidadeRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.Listar());
        }
    }
}
