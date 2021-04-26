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
    public class tipoUsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos
        /// </summary>
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public tipoUsuarioController()
        {
            _TipoUsuarioRepository = new tipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<tipoUsuarioDomain> listaTipoUsuarios = _TipoUsuarioRepository.ListarTodos();

            return Ok(listaTipoUsuarios);
        }

        [HttpPost]
        public IActionResult Post(tipoUsuarioDomain novoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }
    }
}
