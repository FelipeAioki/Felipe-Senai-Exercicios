using Microsoft.AspNetCore.Mvc;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using Sp_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.Controllers
{
    //define que o tipo de reposta da API será no formato JSON
    [Produces("application/json")]
    //define que a rota de uma requisição será no formato domínio/api/NomeController
    //ex: http://localhost:5000/api/calsses
    [Route("api/[controller]")]
    //Define que é um controlador de API
    [ApiController]
    public class usuarioController : ControllerBase
    {
        /// <summary>
        /// Obejto _classesRepository irá receber todos os métodos definidos na interface IClassesRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        public usuarioController()
        {
            _usuarioRepository = new usuarioRepository();
        }

        /// <summary>
        /// Lista todasos usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - ok </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_usuarioRepository.Listar());
        }

        ///// <summary>
        ///// Busca o usuario pelo seu id
        ///// </summary>
        ///// <param name="id">Id da classe que será buscada</param>
        ///// <returns> a classe encontrada e um status code 200 - ok</returns>
        //[HttpGet("{id}")]
        //public IActionResult GetByid(int id)
        //{
        //    //return ex: reposta da requisição fazendo a chamada para o método
        //    return Ok(_usuarioRepository.buscarPorEmailSenha(id));
        //}

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovaUsuario">objeto NovoUsuario que será cadastrado</param>
        /// <returns>um statud code 201- Created</returns>
        [HttpPost]
        public IActionResult Post(Usuario NovoUsuario)

        {
            //faza a chamada para o método 
            _usuarioRepository.Cadastrar(NovoUsuario);

            return StatusCode(201);
        }


    }
}
