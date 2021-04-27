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
    public class usuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o obejto para que haja a referencia nos metodos implementados no repositorio
        /// </summary>
        public usuariosController()
        {
            _usuarioRepository = new usuarioRepository();
        }
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }
    }
}
