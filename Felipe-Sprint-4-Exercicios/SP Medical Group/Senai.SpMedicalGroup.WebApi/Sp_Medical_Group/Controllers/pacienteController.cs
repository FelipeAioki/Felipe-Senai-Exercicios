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
    public class pacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public pacienteController()
        {
            _pacienteRepository = new pacienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_pacienteRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Paciente NovoPaciente)

        {
            //faza a chamada para o método 
            _pacienteRepository.Cadastrar(NovoPaciente);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _pacienteRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }
    }
}
