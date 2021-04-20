using Microsoft.AspNetCore.Http;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos
        /// </summary>
        private ILoginRepository _LoginRepository { get; set; }

        public LoginController()
        {
            _LoginRepository = new loginRepository();
        }


        /// <summary>
        /// Uma lista dos tipo de usuarios
        /// </summary>
        /// <returns>Uma lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<loginDomain> listaTiposUsuarios = _LoginRepository.Listar();

            return Ok(listaTiposUsuarios);
        }

        [HttpPost]
        public IActionResult Post(loginDomain novoUsuario)
        {
            _LoginRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }
    }

}

