using Microsoft.AspNetCore.Mvc;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_CZBooks.webapi.Controllers
{
    //define que o tipo de reposta da API será no formato JSON
    [Produces("application/json")]
    //define que a rota de uma requisição será no formato domínio/api/NomeController
    //ex: http://localhost:5000/api/'nome'
    [Route("api/[controller]")]
    //Define que é um controlador de API
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public usuariosController()
        {
            _usuarioRepository = new Repositories.usuarioRepository();
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_usuarioRepository.Listar());
        }
    }
}
