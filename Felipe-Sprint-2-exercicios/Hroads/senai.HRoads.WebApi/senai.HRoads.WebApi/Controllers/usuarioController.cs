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
    public class usuarioController : ControllerBase
    {

        /// <summary>
        /// Objeto que irá receber todos os métodos
        /// </summary>
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public usuarioController()
        {
            _UsuarioRepository = new usuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<usuarioDomain> listaJogos = _UsuarioRepository.ListarTodos();

            return Ok(listaJogos);
        }

        [HttpPost]
        public IActionResult Post(usuarioDomain novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }
    }
}
