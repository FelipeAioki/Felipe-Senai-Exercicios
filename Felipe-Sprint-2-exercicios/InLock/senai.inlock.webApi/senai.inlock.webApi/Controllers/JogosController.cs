using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("aplication/json")]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new jogoRepository();
        }

        /// <summary>
        /// Uma lista de todos os Gêneros
        /// </summary>
        /// <returns>Uma lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<jogoDomain> listaJogos = _jogoRepository.ListarTodos();

            return Ok();
        }
    }
}
