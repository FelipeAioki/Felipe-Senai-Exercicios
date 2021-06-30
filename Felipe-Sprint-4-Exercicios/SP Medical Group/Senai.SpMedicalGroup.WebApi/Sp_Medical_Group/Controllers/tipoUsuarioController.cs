using Microsoft.AspNetCore.Authorization;
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
    public class tipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public tipoUsuarioController()
        {
            _tipoUsuarioRepository = new tipoUsuarioRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _tipoUsuarioRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }
    }
}
