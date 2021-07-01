using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sp_Medical_Group.Domains;
using Sp_Medical_Group.Interfaces;
using Sp_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        /// Obejto _usuarioRepository irá receber todos os métodos definidos na interface IusuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        public usuarioController()
        {
            _usuarioRepository = new usuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - ok </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_usuarioRepository.Listar());
        }

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

        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.buscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha invalidos!");
            }
            var claims = new[]
            {
                                                //Tipo de claim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("Claim Personalizada", "Valor teste")

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuarios-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "SpMeidcalGroup.webApi",  //Emissor do token
                audience: "SpMedicalGroup.webApi", //Quem recebe o token, para fazer a validação
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), //Acrescenta alguns minutos á expiração do token
                signingCredentials: creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _usuarioRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }

    }
}
