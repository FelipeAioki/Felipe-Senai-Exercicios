using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_CZBooks.webapi.Domains;
using senai_CZBooks.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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


        /// <summary>
        /// Login Controller
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
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
                new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuarios-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "senai_CZBooks.webApi",  //Emissor do token
                audience: "senai_CZBooks.webApi", //Quem recebe o token, para fazer a validação
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), //Acrescenta alguns minutos á expiração do token
                signingCredentials: creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
