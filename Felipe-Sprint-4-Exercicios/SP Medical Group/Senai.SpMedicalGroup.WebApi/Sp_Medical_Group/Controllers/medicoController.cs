using Microsoft.AspNetCore.Mvc;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using Sp_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class medicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public medicoController()
        {
            _medicoRepository = new medicoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_medicoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Medico NovoMedico)

        {
            //faza a chamada para o método 
            _medicoRepository.Cadastrar(NovoMedico);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _medicoRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        public IActionResult ListarTodasConsultas(int id)
        {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_medicoRepository.ListarTodosIdMedico(idMedico));
        }
    }
}
