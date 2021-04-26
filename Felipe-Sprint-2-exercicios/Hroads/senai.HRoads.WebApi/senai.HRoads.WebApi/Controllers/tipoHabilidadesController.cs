using Microsoft.AspNetCore.Mvc;
using senai.HRoads.WebApi.Domains;
using senai.HRoads.WebApi.Interfaces;
using senai.HRoads.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRoads.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class tipoHabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos
        /// </summary>
        private ITipoHabilidadeRepository _TipoHabilidadesRepository { get; set; }

        public tipoHabilidadesController()
        {
            _TipoHabilidadesRepository = new tipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<tipoHabilidadeDomain> listaTipoHabilidades= _TipoHabilidadesRepository.ListarTodos();

            return Ok(listaTipoHabilidades);
        }

        [HttpPost]
        public IActionResult Post(tipoHabilidadeDomain novoTipoHabilidade)
        {
            _TipoHabilidadesRepository.Cadastrar(novoTipoHabilidade);

            return StatusCode(201);
        }
    }
}
